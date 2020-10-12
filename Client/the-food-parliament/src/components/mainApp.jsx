import React from 'react';
import UserSelector from './user/userSelector';
import RestaurantSelector from './restaurant/restaurantSelector';
import Vote from './vote/vote';
import VoteResult from './vote/voteResult';

export default class MainApp extends React.Component {
    constructor() {
        super();

        this.state = {
            user: null,
            restaurant: null,
            vote: null,
            showVoteResult: false
        };
    }

    onUserSelect = (user) => {
        this.setState({ user });
    }

    onRestaurantSelect = (restaurant) => {
        console.log('Restaurant', restaurant);
        this.setState({ restaurant });
    }

    onVoteResult = (vote) => {
        this.setState({ showVoteResult: true, vote })
    }

    onVoteCancel = () => {
        this.onRestaurantSelect(null);
    }

    reset = () => {
        this.setState({
            user: null,
            restaurant: null,
            vote: null,
            showVoteResult: false
        });
    }

    render() {
        if (this.state.showVoteResult)
            return (<VoteResult vote={this.state.vote} reset={this.reset} />)

        if (!this.state.user)
            return (<UserSelector selectedUser={this.onUserSelect} />)

        if (!this.state.restaurant)
            return (<RestaurantSelector selectedRestaurant={this.onRestaurantSelect} />)

        return (<Vote user={this.state.user}
            restaurant={this.state.restaurant}
            voteResult={(vote) => this.onVoteResult(vote)}
            onVoteCancel={this.onVoteCancel} />)
    }
}