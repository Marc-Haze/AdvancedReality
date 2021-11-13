module.exports = app => {
    const text = require("../controllers/texts.controller.js");
    const auth = require("../controllers/auth.js");
  
    var router = require("express").Router();
  
    // Create a new contactMessage
    router.post("/", text.create);
  
    // Retrieve all contactMessages
    router.get("/", text.findAll);

    // Retrieve a single contactMessage with id
    router.get("/:id", text.findOne);
  
    // Update a contactMessage with id
    router.put("/:id", text.update);
  
    // Delete a contactMessage with id
    router.delete("/:id", text.delete);
  
    app.use('/api/texts', router);
  };