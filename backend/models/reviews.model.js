module.exports = (sequelize, Sequelize) => {
    const Review = sequelize.define("review", {
      content: {
        type: Sequelize.STRING
      },
      username: {
        type: Sequelize.STRING
      },
      target: {
        type: Sequelize.STRING
      }
    });
  
    Review.associate = function(models) {
      Review.belongsTo(models.user, {
        onDelete: "CASCADE",
        foreignKey: "userId",
        as: "users",
      })
    }
  
    return Review;
  };