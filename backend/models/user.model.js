module.exports = (sequelize, Sequelize) => {
  const User = sequelize.define("user", {
    username: {
      type: Sequelize.STRING
    },
    password: {
      type: Sequelize.STRING
    },
    mail: {
      type: Sequelize.STRING
    },
    darkmode: {
      type: Sequelize.BOOLEAN
    },
    isAdmin: {
      type: Sequelize.BOOLEAN
    }
  });

  return User;
};