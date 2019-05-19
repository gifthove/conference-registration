const attendees = [
  {
    id: 1,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 2,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 3,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 4,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 5,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 6,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 7,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 8,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 9,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  },
  {
    id: 10,
    title: "Mr",
    firstName: "Gift",
    lastName: "Hove",
    category: "JavaScript"
  }
];

const newAttendee = {
  id: 0,
  title: "",
  firstName: "",
  lastName: "",
  category: ""
};

const newRegistration = {
  id: 0,
  attendee: {
    title: "",
    firstName: "",
    lastName: "",
    addressLine1: "",
    addressLine2: "",
    company: "",
    workphone: "",
    mobilePhone: "",
    email: "",
    id: 0,
    position: "",
    department: "",
    postalCode: "",
    city: "",
    country: "",
    fax: ""
  },
  conferenceId: 1,
  attendingSessions: [
    {
      sessionId: 1,
      session: {
        topic: "Test",
        startTime: "2019-05-04T19:00:00",
        endTime: "2019-05-04T18:57:00",
        id: 1
      },
      id: 0
    }
  ]
};

const DefaultOption = { value: "", text: "Select a Title" };

const Titles = [
  {
    value: "Mr",
    text: "Mr"
  },
  {
    value: "Mrs",
    text: "Mrs"
  }
];

// Using CommonJS style export so we can consume via Node (without using Babel-node)
module.exports = {
  newAttendee,
  attendees,
  newRegistration,
  Titles,
  DefaultOption
  // authors
};
