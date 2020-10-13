import React from 'react';
import UserSelector from './user/userSelector';
import RestaurantSelector from './restaurant/restaurantSelector';
import Vote from './vote/vote';
import VoteResult from './vote/voteResult';
import ParliamentService from '../services/parliamentService';

export default class MainApp extends React.Component {
    constructor() {
        super();

        this.state = {
            user: null,
            restaurant: null,
            vote: null,
            lastWinner: null,
            showVoteResult: false,
            isElectionOpen: false,
        };
        this.parliamentService = new ParliamentService();
    }

    async componentDidMount() {
        let lastWinner = null;
        const electionOpened = await this.parliamentService.isElectionOpen();
        if (!electionOpened.data) {
            lastWinner = (await this.parliamentService.getLastWinner()).data;
            console.log('LastWinner', lastWinner);
        }

        this.setState({
            isElectionOpen: electionOpened.data,
            lastWinner
        })
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
        if (!this.state.isElectionOpen)
            return (
                <div>

                    <p>A votação ainda não começou.<br />
                       Ela abre as 08:00 horas e vai até as 11:59 horas. <br />
                       Enquanto isto confira o último vencedor da eleição:
                    </p>

                    {this.state.lastWinner &&
                        (this.state.lastWinner.status
                            ? `${this.state.lastWinner.result.restaurant.name} com ${this.state.lastWinner.result.votes} votos em ${this.state.lastWinner.result.winningDate}!`
                            : this.state.lastWinner.message)
                    }
                </div>
            )

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