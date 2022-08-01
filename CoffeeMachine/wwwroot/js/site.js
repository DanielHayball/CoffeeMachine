
$('.js-drinks-button').on('click', function (e) {

    var drinkType = this.getAttribute('data-drink-type');

    if (drinkType === null || drinkType.match(/^ *$/) !== null) {
        console.log("no drink type found");
        return;
    }

    $('.coffee-machine__on-light').addClass('preparing');

    console.log("clicked " + drinkType.toString() + " button");

    $.ajax({
        method: 'GET',
        url: "/Home/GetDrinkRecipe",
        dataType: "json",
        data: { drinkType },
        success: function (data) {

            var textSpace = $('.home__drink-recipe-space');
            var recipeStep = 0;

            textSpace.removeClass('hide');

            for (var i = 0; i <= data.orderOfOperations.length; i++) {

                if (i < data.orderOfOperations.length) {
                    setTimeout(function () {
                        textSpace.text(data.orderOfOperations[recipeStep]);
                        recipeStep++;
                    }, (i * 1500));
                }
                else {
                    setTimeout(function () {
                        textSpace.text("Enjoy your drink!");

                        $('.coffee-machine__on-light').removeClass('preparing');

                        $('.coffee-machine__drink-shoot-image').addClass('hide');

                        switch (data.name) {
                            case "LemonTea":
                                $('.coffee-machine__drink-shoot-image.lemon-tea').removeClass('hide');
                                break;
                            case "Coffee":
                                $('.coffee-machine__drink-shoot-image.coffee').removeClass('hide');
                                break;
                            case "Chocolate":
                                $('.coffee-machine__drink-shoot-image.chocolate').removeClass('hide');
                                break;
                        }

                    }, (i * 1500));
                }
            }

        },
        fail: function (data) {
            console.log("failed to get drink recipe")
        }
    });
});

$('.coffee-machine__drink-shoot-image').on('click', function (e) {
    $('.coffee-machine__drink-shoot-image').addClass('hide');
    $('.home__drink-recipe-space').text("");
});
