module.exports = (sequelize, Sequelize) => {
    const Image = sequelize.define("image", {
        name: {
            type: Sequelize.STRING
        },
        fileName: {
            type: Sequelize.STRING
        },
        place: {
            type: Sequelize.STRING
        }
    });
    return Image;
};