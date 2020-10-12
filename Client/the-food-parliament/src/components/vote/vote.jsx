import React from 'react';
import ParliamentService from '../../services/parliamentService';
import './vote.css'

export default class Vote extends React.Component {
    constructor(props) {
        super(props);
        this.parliamentService = new ParliamentService();
    }

    castVote = async () => {
        const voteResult = await this.parliamentService.castVote(this.props.user.id, this.props.restaurant.id);
        this.props.voteResult(voteResult.data);
    }

    render() {
        return (
            <div>
                <p>Você tem certeza que ver votar no restaurante <b>{this.props.restaurant.name}</b>, <br /> localizado na <b>{this.props.restaurant.address}</b></p>
                <button className="vote-button" onClick={this.castVote}>Votar</button>
                <button className="cancel-button" onClick={this.props.onVoteCancel}>Cancelar</button>
            </div >
        )
    }
}