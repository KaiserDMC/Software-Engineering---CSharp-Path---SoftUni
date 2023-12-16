const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

const DEBUG = false;
const slowMo = 500;

const mockData = {
  list: [
    {
      food: 'Bug 1',
      calories: '5',
      time: '11:35',
      _id: '1001',
    },
    {
      food: 'Bug 2',
      calories: '3',
      time: '14:50',
      _id: '1002',
    },
    {
      food: 'Bug 3',
      calories: '4',
      time: '23:20',
      _id: '1003',
    },
    {
      food: 'Bug 4',
      calories: '8',
      time: '07:00',
      _id: '1004',
    },
  ],
};

const endpoints = {
  catalog: '/jsonstore/tasks',
  byId: (id) => `/jsonstore/tasks/${id}`,
};

let browser;
let context;
let page;

describe('E2E tests', function () {
  // Setup
  this.timeout(DEBUG ? 120000 : 7000);
  before(
    async () =>
    (browser = await chromium.launch(
      DEBUG ? { headless: false, slowMo } : {}
    ))
  );
  after(async () => await browser.close());
  beforeEach(async () => {
    context = await browser.newContext();
    setupContext(context);
    page = await context.newPage();
  });
  afterEach(async () => {
    await page.close();
    await context.close();
  });

  describe('Daily Calorie Counter Tests', () => {
    it('Load Meals', async () => {
      const data = mockData.list;
      const { get } = await handle(endpoints.catalog);
      get(data);

      await page.goto(host);
      await page.waitForSelector('#load-meals');

      await page.click('#load-meals');

      const list = await page.$$eval(`#meals #list .meal`, (t) =>
        t.map((s) => s.textContent)
      );
      expect(list.length).to.equal(data.length);

    });

   it('Add Meal', async () => {
      const data = mockData.list[0];
      await page.goto(host);

      const { post } = await handle(endpoints.catalog);
      const { onRequest } = post();

      await page.waitForSelector('#form');
      await page.fill('#food', data.food);
      await page.fill('#time', data.time);
      await page.fill('#calories', data.calories);

      const [request] = await Promise.all([
        onRequest(),
        page.click('#add-meal'),
      ]);

      const postData = JSON.parse(request.postData());
      
      expect(postData.food).to.equal(data.food);
      expect(postData.time).to.equal(data.time);
      expect(postData.calories).to.equal(data.calories);

      const [food] = await page.$$eval(`#food`, (t) =>
        t.map((s) => s.value)
      );
      const [time] = await page.$$eval(`#time`, (t) =>
        t.map((s) => s.value)
      );

      const [calories] = await page.$$eval(`#calories`, (t) =>
        t.map((s) => s.value)
      );

      expect(food).to.equal('');
      expect(time).to.equal('');
      expect(calories).to.equal('');
    });

    it('Edit Meal (Has Input)', async () => {
      await page.goto(host);
      const data = mockData.list[0];

      await page.click('#load-meals');
      await page.waitForSelector('#list');
      await page.click('#list .meal .change-meal');

      const allCourse = await page.$$eval(`#form input`, (t) =>
        t.map((s) => s.value)
      );

   

      expect(allCourse[0]).to.include(data.food);
      expect(allCourse[1]).to.include(data.time);
      expect(allCourse[2]).to.include(data.calories);

    });

    it('Edit Meal (Makes API Call)', async () => {
      const data = mockData.list[0];
      await page.goto(host);
      const { patch } = await handle(endpoints.byId(data._id));
      const { onRequest } = patch({ id: data._id });

      await page.click('#load-meals');
      await page.waitForSelector('#list');
      await page.click('#list .meal .change-meal');
      await page.fill('#food', data.food + 's');

      const [request] = await Promise.all([
        onRequest(),
        page.click('#edit-meal'),
      ]);

      const postData = JSON.parse(request.postData());
      expect(postData.food).to.equal(data.food + 's');
    });

    it('Delete Meal', async () => {
      const data = mockData.list[0];
      await page.goto(host);
      const { del } = await handle(endpoints.byId(data._id));
      const { onResponse, isHandled } = del({ id: data._id });

      await page.click('#load-meals');

      await page.waitForSelector('#list');

      await Promise.all([
        onResponse(),
        page.click(
          `#list .meal .delete-meal`
        ),
      ]);

      expect(isHandled()).to.be.true;
    });
  });
});

async function setupContext(context) {
  // Catalog and Details
  await handleContext(context, endpoints.catalog, { get: mockData.list });
  await handleContext(context, endpoints.catalog, { post: mockData.list[0] });

  await handleContext(context, endpoints.byId('1001'), {
    get: mockData.list[0],
  });

  // Block external calls
  await context.route(
    (url) => url.href.slice(0, host.length) != host,
    (route) => {
      if (DEBUG) {
        console.log('Preventing external call to ' + route.request().url());
      }
      route.abort();
    }
  );
}

function handle(match, handlers) {
  return handleRaw.call(page, match, handlers);
}

function handleContext(context, match, handlers) {
  return handleRaw.call(context, match, handlers);
}

async function handleRaw(match, handlers) {
  const methodHandlers = {};
  const result = {
    get: (returns, options) => request('GET', returns, options),
    get2: (returns, options) => request('GET', returns, options),
    post: (returns, options) => request('POST', returns, options),
    put: (returns, options) => request('PUT', returns, options),
    patch: (returns, options) => request('PATCH', returns, options),
    del: (returns, options) => request('DELETE', returns, options),
    delete: (returns, options) => request('DELETE', returns, options),
  };

  const context = this;

  await context.route(urlPredicate, (route, request) => {
    if (DEBUG) {
      console.log('>>>', request.method(), request.url());
    }

    const handler = methodHandlers[request.method().toLowerCase()];
    if (handler == undefined) {
      route.continue();
    } else {
      handler(route, request);
    }
  }); ``

  if (handlers) {
    for (let method in handlers) {
      if (typeof handlers[method] == 'function') {
        handlers[method](result[method]);
      } else {
        result[method](handlers[method]);
      }
    }
  }

  return result;

  function request(method, returns, options) {
    let handled = false;

    methodHandlers[method.toLowerCase()] = (route, request) => {
      handled = true;
      route.fulfill(respond(returns, options));
    };

    return {
      onRequest: () => context.waitForRequest(urlPredicate),
      onResponse: () => context.waitForResponse(urlPredicate),
      isHandled: () => handled,
    };
  }

  function urlPredicate(current) {
    if (current instanceof URL) {
      return current.href.toLowerCase().includes(match.toLowerCase());
    } else {
      return current.url().toLowerCase().includes(match.toLowerCase());
    }
  }
}

function respond(data, options = {}) {
  options = Object.assign(
    {
      json: true,
      status: 200,
    },
    options
  );

  const headers = {
    'Access-Control-Allow-Origin': '*',
  };
  if (options.json) {
    headers['Content-Type'] = 'application/json';
    data = JSON.stringify(data);
  }

  return {
    status: options.status,
    headers,
    body: data,
  };
}
