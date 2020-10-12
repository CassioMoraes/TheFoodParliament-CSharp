import React from 'react';
import ParliamentService from '../../services/parliamentService';
import Select from 'react-select'
import './userSelector.css';

export default class UserSelector extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            users: null,
            userOptions: null
        };
        this.parliamentService = new ParliamentService();
    }

    async componentDidMount() {
        const users = await this.parliamentService.getUsers();
        const userOptions = users.data.map((user) => { return { value: user.id, label: user.name } })
        this.setState({ users: users.data, userOptions })
    }

    userSelected = (e) => {
        const selectedUser = this.state.users.find((user) => user.id === e.value);
        this.props.selectedUser(selectedUser);
    }


    render() {
        if (!this.state.userOptions) {
            return null;
        }
        return (
            <div>
                <p>Selecione seu usuário: </p>
                <Select className="select-item" options={this.state.userOptions} onChange={(e) => this.userSelected(e)} />
            </div>
        )
    }
}