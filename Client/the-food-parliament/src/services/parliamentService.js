import axios from 'axios';

export default class ParliamentService {
    constructor() {
        this.axios = axios.create({
            baseURL: 'http://localhost:5000/',
        });
    }

    getUsers() {
        return this.axios.get('user/');
    }

    getRestaurants() {
        return this.axios.get('restaurant');
    }

    castVote(userId, restaurantId) {
        const vote = { userId, restaurantId };
        return this.axios.post('vote', vote);
    }
}