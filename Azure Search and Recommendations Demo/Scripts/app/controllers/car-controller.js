angular.module('car-app', []);

angular
    .module('car-app')
    .controller('carController', carController);

carController.$inject = ['dataservice'];

function carController(dataservice) {
    var vm = this;
    vm.cars = [];
    vm.searchTerm;

    vm.search = search;

    function initCars() {      
        dataservice.getAvailableCars().then(function (data) {
            vm.cars = data;
        })
    }

    function search() {
        dataservice.searchCars(vm.searchTerm).then(function (data) {
            vm.cars = data;
        })
    }

    initCars();
}