const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

const DEBUG = false;
const slowMo = 500;

const mockData = {
  list: [
    {
      name: 'Bug 1',
      days: '5',
      date: '2023-07-19',
      _id: '1001',
    },
    {
      name: 'Bug 2',
      days: '3',
      date: '2023-07-13',
      _id: '1002',
    },
    {
      name: 'Bug 3',
      days: '4',
      date: '2023-07-12',
      _id: '1003',
    },
    {
      name: 'Bug 4',
      days: '8',
      date: '2023-07-11',
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

  describe('Vacation Schedule Tests', () => {
    it('Load Vacation', async () => {
      const data = mockData.list;
      const { get } = await handle(endpoints.catalog);
      get(data);

      await page.goto(host);
      await page.waitForSelector('#load-vacations');

      await page.click('#load-vacations');

      const list = await page.$$eval(`#confirmed-vacantions #list .container`, (t) =>
        t.map((s) => s.textContent)
      );
      expect(list.length).to.equal(data.length);

    });

   it('Add Vacation', async () => {
      const data = mockData.list[0];
      await page.goto(host);

      const { post } = await handle(endpoints.catalog);
      const { onRequest } = post();

      await page.waitForSelector('#form');
      await page.fill('#name', data.name);
      await page.fill('#num-days', data.days);
      await page.fill('#from-date', data.date);

      const [request] = await Promise.all([
        onRequest(),
        page.click('#add-vacation'),
      ]);

      const postData = JSON.parse(request.postData());
      
      expect(postData.name).to.equal(data.name);
      expect(postData.days).to.equal(data.days);
      expect(postData.date).to.equal(data.date);

      const [name] = await page.$$eval(`#name`, (t) =>
        t.map((s) => s.value)
      );
      const [numDays] = await page.$$eval(`#num-days`, (t) =>
        t.map((s) => s.value)
      );

      const [date] = await page.$$eval(`#from-date`, (t) =>
        t.map((s) => s.value)
      );

      expect(name).to.equal('');
      expect(numDays).to.equal('');
      expect(date).to.equal('');
    });

    it('Edit Vacation (Has Input)', async () => {
      await page.goto(host);
      const data = mockData.list[0];

      await page.click('#load-vacations');
      await page.waitForSelector('#list');
      await page.click('#list .container .change-btn');

      const allCourse = await page.$$eval(`#form input`, (t) =>
        t.map((s) => s.value)
      );

   

      expect(allCourse[0]).to.include(data.name);
      expect(allCourse[1]).to.include(data.days);
      expect(allCourse[2]).to.include(data.date);

    });

    it('Edit Vacation (Makes API Call)', async () => {
      const data = mockData.list[0];
      await page.goto(host);
      const { patch } = await handle(endpoints.byId(data._id));
      const { onRequest } = patch({ id: data._id });

      await page.click('#load-vacations');
      await page.waitForSelector('#list');
      await page.click('#list .container .change-btn');
      await page.fill('#name', data.name + '2');

      const [request] = await Promise.all([
        onRequest(),
        page.click('#edit-vacation'),
      ]);

      const postData = JSON.parse(request.postData());
      expect(postData.name).to.equal(data.name + '2');
    });

    it('Schedule Done', async () => {
      const data = mockData.list[0];
      await page.goto(host);
      const { del } = await handle(endpoints.byId(data._id));
      const { onResponse, isHandled } = del({ id: data._id });

      await page.click('#load-vacations');

      await page.waitForSelector('#list');

      await Promise.all([
        onResponse(),
        page.click(
          `#list .container .done-btn`
        ),
      ]);

      expect(isHandled()).to.be.true;
    });
  });
});

async function setupContext(context) {
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

  await handleContext(context, endpoints.byId('1001'), {
    get: mockData.list[0],
  });

  await handleContext(context, endpoints.catalog, { post: mockData.list[0] });
  // Catalog and Details
  await handleContext(context, endpoints.catalog, { get: mockData.list });
  

  
 
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
