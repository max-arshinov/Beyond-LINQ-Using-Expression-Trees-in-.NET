import React, { Component } from 'react';

export class FilterSort extends Component {
  static displayName = FilterSort.name;

  constructor(props) {
    super(props);
    this.state = { 
      data: [], 
      filter: {
        name: '',
        price: '',
        orderBy: 'name'
      },
      loading: true 
    };
  }

  componentDidMount() {
    this.populateData();
  }

  handleChange(inputName, event) {
    this.setState({
      filter: {...this.state.filter, [inputName]: event.target.value}
    });
  }
  
  static renderDataTable(data) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Category</th>
            <th>Name</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
          {data.map(data =>
            <tr key={data.id}>
              <td>{data.categoryName}</td>
              <td>{data.name}</td>
              <td>{data.price}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FilterSort.renderDataTable(this.state.data);

    return (
      <div>
        <h1 id="tabelLabel" >Filter & Sort</h1>
        <form onSubmit={this.onFilter.bind(this)}>
          <table className="table">
            <tbody>
              <tr>
                <td>Name</td>
                <td><input type="text" value={this.state.filter.name} onChange={this.handleChange.bind(this, 'name')} /></td>
              </tr>
              <tr>
                <td>Price</td>
                <td><input type="text" value={this.state.filter.price} onChange={this.handleChange.bind(this, 'price')} /></td>
              </tr>
              <tr>
                <td>Sort By</td>
                <td>
                  <select value={this.state.filter.orderBy} onChange={this.handleChange.bind(this, 'orderBy')}>
                    <option value="name">Name</option>
                    <option value="price">Price</option>
                  </select>
                </td>
              </tr>
            </tbody>
          </table>

          <br/>
          <input className="btn btn-primary" type="submit" value="Filter" />
          <br/>
        </form>
        <br/>
        {contents}
      </div>
    );
  }

  async populateData() {
    const esc = encodeURIComponent;
    const query = Object.keys(this.state.filter)
        .map(k => esc(k) + '=' + (this.state.filter[k] ? esc(this.state.filter[k]) : ''))
        .join('&');
    
    const response = await fetch('api/products?' + query);
    const data = await response.json();
    this.setState({ data: data, loading: false });
  }

  onFilter(e) {
    console.log('da')
    this.populateData();
    e.preventDefault();
    return false;
  }
}
