module.exports = app => {
    const reviews = require("../controllers/reviews.controller.js");
    const auth = require("../controllers/auth.js");
  
    var router = require("express").Router();
  
    // Create a new Comment
    router.post("/", reviews.create);
  
    // Retrieve all Comments
    router.get("/", reviews.findAll);

    // Retrieve a single Comment with id
    router.get("/:id", reviews.findOne);
  
    // Update a Comment with id
    router.put("/:id", reviews.update);
  
    // Delete a Comment with id
    router.delete("/:id", reviews.delete);
  
    app.use('/api/reviews', router);
  };