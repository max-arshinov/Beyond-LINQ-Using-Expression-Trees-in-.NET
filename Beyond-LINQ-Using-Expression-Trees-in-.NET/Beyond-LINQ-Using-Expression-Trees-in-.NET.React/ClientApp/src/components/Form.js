import React, { Component } from 'react';
import t from 'tcomb-form';

const FormSchema = t.struct({
  name: t.String,         // a required string
  age: t.maybe(t.Number), // an optional number
  rememberMe: t.Boolean   // a boolean
})

export class Form extends Component {
  static displayName = Form.name;

  constructor(props) {
    super(props);
    this.state = { };
    this.formRef = React.createRef();
  }

  componentDidMount() {
    this.populateData();
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

  onSubmit(evt) {
    evt.preventDefault()
    const value = this.formRef.current.getValue();
    if (value) {
      console.log(value)
    }
  }

  render() {
    return (
        <form onSubmit={this.onSubmit.bind(this)}>
          <t.form.Form ref={this.formRef} type={FormSchema} />
          <div className="form-group">
            <button type="submit" className="btn btn-primary">Save</button>
          </div>
        </form>
    );
  }
}
