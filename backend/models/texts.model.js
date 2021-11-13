module.exports = (sequelize, Sequelize) => {
    const Text = sequelize.define("text", {
      content: {
        type: Sequelize.STRING
      },
      mail: {
        type: Sequelize.STRING
      },
    });
  
    Text.associate = function(models) {
      Text.belongsTo(models.user, {
        onDelete: "CASCADE",
        foreignKey: "userId",
        as: "users",
      })
    }
  
    return Text;
  };