angular
    .module('car-app')
    .factory('dataservice', dataservice);

dataservice.$inject = ['$http'];

function dataservice($http) {
    
    var service = {
        getAvailableCars: getAvailableCars,
        searchCars: searchCars
    };

    return service;

    function getAvailableCars() {
        return $http.get('/api/Search/GetCars')
            .then(getAvailableCarsComplete)
            .catch(getAvailableCarsFailed);

        function getAvailableCarsComplete(response) {
            return response.data;
        }

        function getAvailableCarsFailed(error) {
            logger.error('XHR Failed for getCars.' + error.data);
        }
    }

    function searchCars(searchTerm) {
        return $http.post('/api/Search/CarsSearch', JSON.stringify(searchTerm))
            .then(searchCarsComplete)
            .catch(searchCarsFailed);

        function searchCarsComplete(response) {
            return response.data;
        }

        function searchCarsFailed(error) {
            logger.error('XHR Failed for getCars.' + error.data);
        }
    }
}