import React, { Component } from 'react';
import t from 'tcomb-form';

const FormSchema = t.struct({
  name: t.String,         // a required string
  price: t.maybe(t.Number), // an optional number
  category: t.String
})

export class Form extends Component {
  static displayName = Form.name;

  constructor(props) {
    super(props);
    this.state = {
      formSchema: FormSchema
    };
    this.formRef = React.createRef();
  }

  componentDidMount() {
    this.getRefinement()
  }

  async getRefinement() {
    const response = await fetch('api/form');
    const data = await response.json();
    const price = t.refinement(t.Number, eval(data.predicate));
    price.getValidationErrorMessage = () => data.errorMessage;
    this.setState({
      formSchema: t.struct({
        name: t.String,
        price: price,
        category: t.String
      })
    })
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
          <t.form.Form ref={this.formRef} type={this.state.formSchema} />
          <div className="form-group">
            <button type="submit" className="btn btn-primary">Save</button>
          </div>
        </form>
    );
  }
}
