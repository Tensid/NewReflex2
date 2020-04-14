import React, { useEffect, useRef } from 'react';
import $ from 'jquery';
import Bloodhound from 'corejs-typeahead';
import 'corejs-typeahead/dist/typeahead.jquery.js';
import './typeaheadjs.css';
import { connect } from 'react-redux';
import { setSearchResult } from '../search-result/searchResultSlice';

const Typeahead = (props) => {
  const el = useRef();

  useEffect(() => {
    const estates = new Bloodhound({
      datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
      queryTokenizer: Bloodhound.tokenizers.whitespace,
      remote: {
        url: 'api/search/?query=%QUERY',
        wildcard: '%QUERY'
      }
    });

    const $el = $(el.current);
    $el.typeahead({
      highlight: true,
      hint: false,
      minLength: 3
    }, {
      name: 'estates',
      source: estates,
      limit: 10,
      display: (item) => { return item.addressName ? item.addressName : item.estateName; },
      templates: {
        suggestion: (data) => {
          if (data.addressName)
            return `<span>${data.addressName} - ${data.estateName}</span>`;
          return `<span>${data.estateName}</span>`;
        }
      }
    });

    $el.on('typeahead:selected',
      (e, data) => {
        props.onSelectCallback(data);
      });
    $el.typeahead('val', props?.searchResult?.estateName || '');
  });
  return (
    <input autoComplete="off" ref={el} className="form-control col-sm-8 col-md-6 col-lg-3 col-12" id="search_input" type="text" autoFocus="autofocus" placeholder="Sök fastighet eller adress..."></input>
  );
};

const mapDispatch = { setSearchResult };

const mapStateToProps = state => ({
  searchResult: state.searchResult
});

export default connect(
  mapStateToProps,
  mapDispatch
)(Typeahead);
