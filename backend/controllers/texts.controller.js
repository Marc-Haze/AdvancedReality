const db = require("../models");
const Text = db.text;
const Op = db.Sequelize.Op;

// Create and Save a new ContactMessages
exports.create = (req, res) => {
  // Validate request
  if (!req.body.content || !req.body.mail) {
    res.status(400).send({
      message: "Content can not be empty!"
    });
    return;
  }

  // Create a ContactMessages
  const text = {
    content: req.body.content,
    mail: req.body.mail,
    userId: req.body.userId
  };

  // Save ContactMessages in the database
  Text.create(text)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message:
          err.message || "Some error occurred while creating the message."
      });
    });
};

// Retrieve all ContactMessages from the database.
exports.findAll = (req, res) => {
  Text.findAll()
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

// Find a single ContactMessage with an id
exports.findOne = (req, res) => {
  const id = req.params.id;
  
  Text.findByPk(id)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message: "Error retrieving Comment with id=" + id
      });
    });
};

// Update a ContactMessage by the id in the request
exports.update = (req, res) => {
  const id = req.params.id;

  Text.update(req.body, {
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "ContactMessage was updated successfully."
        });
      } else {
        res.send({
          message: `Cannot update ContactMessage with id=${id}. Maybe ContactMessage was not found or req.body is empty!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error updating ContactMessage with id=" + id
      });
    });
};

// Delete a ContactMessage with the specified id in the request
exports.delete = (req, res) => {
  const id = req.params.id;

  Text.destroy({
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "ContactMessage was deleted successfully!"
        });
      } else {
        res.send({
          message: `Cannot delete ContactMessage with id=${id}. Maybe ContactMessage was not found!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Could not delete ContactMessage with id=" + id
      });
    });
};