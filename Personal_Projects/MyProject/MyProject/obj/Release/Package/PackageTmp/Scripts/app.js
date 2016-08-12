(function(){
	var app = angular.module('store', []); //['store-products']);

	//Controllers
	app.controller('StoreController', ['$http', function ($http) {
	    var store = this;
		store.products = [];
        
		$http.get('../../products.json').success(function(data){
			store.products = data;
		});
	}]);
	
	app.controller('TabController', function(){
		this.tab = 1;

		this.setTab = function(newValue){
			this.tab = newValue;
		};

		this.isSet = function(tabName){
			return this.tab === tabName;
		};
	});

	app.controller('ReviewController', function(){
		this.review = {};

		this.addReview = function(product){
			product.reviews.push(this.review);
			this.review = {};
		};
	});

	//Directives
	app.directive('productTitle', function(){
		return{
			restrict: 'E',						//Type of Directive (Element)
			templateUrl: '../Content/html/product-title.html'	//Url of a template
		};
	});

	app.directive('productMenus', function(){
		return{
			restrict: 'E',
			templateUrl: '../Content/html/product-menus.html',
		};
	});

	app.directive('productGallery', function(){
		return{
			restrict: 'E',
			templateUrl: '../Content/html/product-gallery.html',
			controller:function(){
				this.img = 0;

				this.setImg = function(newValue){
				this.img = newValue || 0;
				};
			},
			controllerAs: 'img'
		}
	});

})();