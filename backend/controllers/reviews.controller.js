const db = require("../models");
const Review = db.review;
const Op = db.Sequelize.Op;

// Create and Save a new Comment
exports.create = (req, res) => {
  // Validate request
  if (!req.body.content || !req.body.username || !req.body.target) {
    res.status(400).send({
      message: "Content can not be empty!"
    });
    return;
  }

  // Create a Comment
  const review = {
    content: req.body.content,
    username: req.body.username,
    target: req.body.target,
    userId: req.body.userId
  };

  // Save Comments in the database
  Review.create(review)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message:
          err.message || "Some error occurred while creating the Image."
      });
    });
};

// Retrieve all Comments from the database.
exports.findAll = (req, res) => {
  Review.findAll()
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message:
          err.message || "Some error occurred while retrieving Comments."
      });
    });
};

// Find a single Comment with an id
exports.findOne = (req, res) => {
  const id = req.params.id;

  Review.findByPk(id)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message: "Error retrieving Comment with id=" + id
      });
    });
};

// Update a Image by the id in the request
exports.update = (req, res) => {
  const id = req.params.id;

  Review.update(req.body, {
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "Comment was updated successfully."
        });
      } else {
        res.send({
          message: `Cannot update Comment with id=${id}. Maybe Comment was not found or req.body is empty!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error updating Comment with id=" + id
      });
    });
};

// Delete a Comment with the specified id in the request
exports.delete = (req, res) => {
  const id = req.params.id;

  Review.destroy({
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "Comment was deleted successfully!"
        });
      } else {
        res.send({
          message: `Cannot delete Comment with id=${id}. Maybe Comment was not found!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Could not delete Comment with id=" + id
      });
    });
};