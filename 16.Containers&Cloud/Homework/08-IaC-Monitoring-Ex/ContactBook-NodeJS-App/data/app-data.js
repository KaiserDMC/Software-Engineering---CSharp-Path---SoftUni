let contacts = [];

function seedSampleData() {
  contacts.length = 0;
  contacts.push({
    id: 1, firstName: "Steve", lastName: "Jobs",
    email: "steve@apple.com", phone: "+1 800 123 456",
    dateCreated: new Date("2021-02-17T14:41:33"), 
    comments: "Steven Jobs was an American business magnate, industrial designer, investor, and media proprietor."
  });
  contacts.push({
    id: 2, firstName: "Michael", lastName: "Jackson",
	  email: "michael@jackson.com", phone: "+1 900 888 777",
    dateCreated: new Date("2021-02-23T11:57:36"), 
    comments: "Michael Joseph Jackson was an American singer, songwriter, and dancer."
  });
  contacts.push({
    id: 3, firstName: "Albert", lastName: "Einstein",
	  email: "albert.e@uzh.ch", phone: "+41 44 634 49 01",
    dateCreated: new Date("2021-02-23T12:03:08"), 
    comments: "Albert Einstein was a German-born theoretical physicist, universally acknowledged to be one of the two greatest physicists of all time, the other being Isaac Newton."
  });
}

function getContacts() {
	return contacts;
}

function findContactById(id) {
  let resultContacts = contacts.filter(c => c.id == id);
  if (resultContacts.length == 1)
    return resultContacts[0];
  else
    return {errMsg: `Cannot find contact by id: ${id}`}
}

function findContactsByKeyword(keyword) {
  if (isParamEmpty(keyword))
    return {errMsg: "Keyword cannot be empty!"};
  keyword = keyword.toLowerCase();
  let resultContacts = contacts.filter(c => 
	  JSON.stringify(c).toLowerCase().includes(keyword)
  );
  return resultContacts;
}

function addContact(firstName, lastName, email, phone, comments) {
  if (isParamEmpty(firstName))
    return {errMsg: "First name cannot be empty!"};
  if (isParamEmpty(lastName))
    return {errMsg: "Last name cannot be empty!"};
  if (! isValidEmail(email))
    return {errMsg: "Invalid email!"};
  let newId = 1; 
  if (contacts.length > 0)
    newId = 1 + contacts[contacts.length-1].id;
  let newContact = {
    id: newId,
	  firstName: firstName,
    lastName: lastName,
	  email: email,
	  phone: phone,
    dateCreated: new Date(),
    comments: comments,
  };
  contacts.push(newContact);
  return {msg: "Contact added.", contact: newContact};
}

function deleteContactById(id) {
  let contactIndex = contacts.findIndex(c => c.id == id);
  if (contactIndex != -1) {
    contacts.splice(contactIndex, 1);
    return {msg: `Contact deleted: ${id}`};
  }
  else
    return {errMsg: `Cannot find contact by id: ${id}`}
}

function isParamEmpty(p) {
  if (typeof(p) != 'string')
    return true;
  if (p.trim().length == 0)
    return true;
  return false;
}

function isValidEmail(email) {
  return /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email);
}

module.exports = {
  seedSampleData,
  getContacts,
  findContactById,
  findContactsByKeyword,
  addContact,
  deleteContactById
};
