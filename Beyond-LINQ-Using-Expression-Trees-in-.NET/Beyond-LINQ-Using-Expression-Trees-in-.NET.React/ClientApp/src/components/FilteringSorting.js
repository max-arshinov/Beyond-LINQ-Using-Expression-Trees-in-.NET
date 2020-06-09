import React, { Component } from 'react';

export class FilteringSorting extends Component {
  static displayName = FilteringSorting.name;

  constructor(props) {
    super(props);
    this.state = { data: [], loading: true };
  }

  componentDidMount() {
    this.populateData();
  }

  static renderDataTable(data) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>1</th>
            <th>2</th>
            <th>3</th>
            <th>4</th>
          </tr>
        </thead>
        <tbody>
          {data.map(data =>
            <tr key={data.date}>
              <td>{data.date}</td>
              <td>{data.temperatureC}</td>
              <td>{data.temperatureF}</td>
              <td>{data.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FilteringSorting.renderDataTable(this.state.data);

    return (
      <div>
        <h1 id="tabelLabel" >Filtering & Sorting</h1>
        <div>
          <table>
            <tr>
              <td>Name</td>
              <td></td>
            </tr>
            <tr>
              <td>Price</td>
              <td></td>
            </tr>
            <tr>
              <td>Sort By</td>
              <td></td>
            </tr>
          </table>
        </div>
        {contents}
      </div>
    );
  }

  async populateData() {
    //const token = await authService.getAccessToken();
    const response = await fetch('api/products', {});
    const data = await response.json();
    this.setState({ data: data, loading: false });
  }
}
