import React from 'react';
import ParliamentService from '../../services/parliamentService';
import Select from 'react-select'
import './restaurantSelector.css';

export default class RestaurantSelector extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            restaurants: null,
            restaurantsOptions: null
        };
        this.parliamentService = new ParliamentService();
    }

    async componentDidMount() {
        const restaurants = await this.parliamentService.getRestaurants();
        console.log('Restaurants', restaurants);
        const restaurantsOptions = restaurants.data.map((restaurant) => { return { value: restaurant.id, label: restaurant.name } })
        this.setState({ restaurants: restaurants.data, restaurantsOptions })
    }

    restaurantSelected = (e) => {
        console.log('E', e);
        const selectedRestaurant = this.state.restaurants.find((restaurant) => restaurant.id === e.value);
        console.log('selectedRestaurant', selectedRestaurant);
        this.props.selectedRestaurant(selectedRestaurant);
    }


    render() {
        if (!this.state.restaurantsOptions) {
            return null;
        }
        return (
            <div>
                <p>Selecione seu restaurante favorito: </p>
                <Select className="select-item" options={this.state.restaurantsOptions} onChange={(e) => this.restaurantSelected(e)} />
            </div>
        )
    }
}