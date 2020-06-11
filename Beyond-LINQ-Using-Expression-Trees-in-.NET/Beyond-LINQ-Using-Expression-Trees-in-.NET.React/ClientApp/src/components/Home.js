import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <p>Thank you for attending my talk.</p>
        <h3>Slides & Repo</h3>
        <ul>
          <li><a href="https://drive.google.com/file/d/13Lj6dOzhZAWXvKPKWicXuC4e46mP9RCR/view?usp=sharing">Slides in PDF format</a></li>
          <li><a href="https://github.com/max-arshinov/Beyond-LINQ-Using-Expression-Trees-in-.NET/">Repository with examples</a></li>
        </ul>
        <h3>Here are some useful links from the presentation</h3>
        <ul>
          <li><a href="https://github.com/hazzik/DelegateDecompiler">Delegate Decompiler</a></li>
          <li><a href="http://www.albahari.com/nutshell/predicatebuilder.aspx">Predicate Builder by Joseph Albahari</a></li>
          <li><a href="https://petemontgomery.wordpress.com/2011/02/10/a-universal-predicatebuilder/">Predicate Builder by Pete Mongomery</a></li>
          <li><a href="https://github.com/navozenko/LinqSpecs">LinqSpecs</a></li>
          <li><a href="https://github.com/gcanti/tcomb-form">TCombForm</a></li>
          <li><a href="https://github.com/ngx-formly/ngx-formly">Ngx-formly</a></li>
          <li><a href="https://vagifabilov.wordpress.com/2010/04/02/dont-use-activator-createinstance-or-constructorinfo-invoke-use-compiled-lambda-expressions/">Don’t use Activator.CreateInstance by Vagif Abilov</a></li>
          <li><a href="https://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison">IOC Container performance review</a></li>
        </ul>
        <h3>Want more?</h3>
        <p> We are working on a <a href="https://github.com/hightechgroup/force">library</a> that corporates the functionality presented in the talk and some more cool stuff.
          The library is under development and isn’t yet ready for production use. However, feel free to examine the code and give us feedback if you like. <a href="mailto:max@hightech.group">Email me</a> if you want to be notified one we release the library.
        </p>
      </div>
    );
  }
}
