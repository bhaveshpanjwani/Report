import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { fetchData: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderDataTable(fetchData) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Label Id</th>
                        <th>Print Job Id</th>
                        <th>Verification Type</th>
                        <th>Passing Grade Threshold</th>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Label Numeric Grade</th>
                        <th>Label Grade</th>
                        <th>Label Status</th>
                        <th>Barcode ID</th>
                        <th>Grade</th>
                        <th>Data</th>
                    </tr>
                </thead>
                <tbody>
                    {fetchData.map(item =>
                        <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.label_Id}</td>
                            <td>{item.print_Job_Id}</td>
                            <td>{item.verification_Type}</td>
                            <td>{item.passing_Grade_Threshold}</td>
                            <td>{item.date}</td>
                            <td>{item.time}</td>
                            <td>{item.label_Numeric_Grade}</td>
                            <td>{item.label_Grade}</td>
                            <td>{item.label_Status}</td>
                            <td>{item.barcode_ID}</td>
                            <td>{item.grade}</td>
                            <td>{item.data}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderDataTable(this.state.fetchData); // Updated function name

        return (
            <div>
                <h1 id="tabelLabel">Data Table</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('api/home'); // Assuming your API endpoint is 'api/home'
        const data = await response.json();
        this.setState({ fetchData: data, loading: false });
    }
}
