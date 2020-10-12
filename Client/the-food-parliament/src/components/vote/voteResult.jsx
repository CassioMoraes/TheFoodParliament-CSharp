import React from 'react';
import './vote.css';

export default class VoteResult extends React.Component {
    render() {
        return (
            <div>
                {this.props.vote.status
                    ? <p>IRRRAAA!!! Seu voto foi computado com sucesso</p>
                    : <div>
                        <p>OOPPSS!!! Seu voto não foi computado</p>
                        <p>Por que: {this.props.vote.message}</p>
                    </div>
                }
                <button className={"reset-button"} onClick={this.props.reset}>Reiniciar!</button>
            </div>
        )
    }
}