import React, { ChangeEvent, useEffect, useMemo, useState } from 'react';
import CircularProgress from '@material-ui/core/CircularProgress';
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';
import Typography from '@material-ui/core/Typography';
import MaterialAutocomplete from '@material-ui/lab/AutoComplete';
import match from 'autosuggest-highlight/match';
import parse from 'autosuggest-highlight/parse';
import throttle from 'lodash/throttle';
import { SearchResult, search } from '../../api/api';

interface AutocompleteProps {
  onSelectCallback: (data: SearchResult) => void;
  searchResult: SearchResult;
}

export default function Autocomplete({ onSelectCallback, searchResult }: AutocompleteProps) {
  const [inputValue, setInputValue] = useState('');
  const [options, setOptions] = useState<SearchResult[]>([]);
  const [loading, setLoading] = useState(false);

  async function getData(val: string, callback: any) {
    setLoading(true);
    const data = await search(val);
    setOptions(data);
    setLoading(false);
    return data;
  }

  function customMatch(text: string, query: string) {
    const results: any[] = [];
    const trimmedQuery = query.trim().toLowerCase();
    const textLower = text.toLowerCase();
    const queryLength = trimmedQuery.length;
    let indexOf = textLower.indexOf(trimmedQuery);
    while (indexOf > -1) {
      results.push([indexOf, indexOf + queryLength]);
      indexOf = textLower.indexOf(query, indexOf + queryLength);
    }
    return results;
  }

  const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    setInputValue(event.target.value);
  };

  const fetch = useMemo(
    () => throttle((request: { input: string; }, callback: (results?: SearchResult[]) => void) => {
      getData(request.input, callback);
    }, 250),
    [],
  );

  useEffect(() => {
    let active = true;

    if (inputValue === '') {
      if (searchResult.displayName) {
        setInputValue(searchResult.displayName);
        setOptions([searchResult]);
      }
      else
        setOptions([]);
      return undefined;
    }

    fetch({ input: inputValue }, (results?: SearchResult[]) => {
      if (active) {
        setOptions(results || []);
      }
    });

    return () => {
      active = false;
    };
  }, [inputValue, fetch, searchResult]);

  return (
    <MaterialAutocomplete
      style={{ width: 300 }}
      getOptionLabel={(option) => (typeof option === 'string' ? option : option.displayName)}
      filterOptions={(x) => x}
      options={options}
      freeSolo
      autoComplete
      includeInputInList
      defaultValue={searchResult}
      loading={loading}
      onChange={(_event: any, newInputValue: any) => newInputValue ? onSelectCallback(newInputValue) : null}
      renderInput={(params) => (
        <TextField
          {...params}
          label="Sök"
          variant="outlined"
          fullWidth
          onChange={handleChange}
          InputProps={{
            ...params.InputProps,
            endAdornment: (
              <>
                {loading ? <CircularProgress color="inherit" size={20} /> : null}
                {params.InputProps.endAdornment}
              </>
            ),
          }}
        />
      )}
      renderOption={(option) => {
        let matches = match(option.displayName, inputValue);

        if (matches?.length < 1 && option.displayName && inputValue)
          matches = customMatch(option.displayName, inputValue);

        const parts = parse(
          option.displayName,
          matches
        );

        return (
          <Grid container alignItems="center">
            <Grid item>
            </Grid>
            <Grid item xs>
              {parts.map((part, index) => (
                <span key={index} style={{ fontWeight: part.highlight ? 700 : 400 }}>
                  {part.text}
                </span>
              ))}
              <Typography variant="body2" color="textSecondary">
                {option.source} | {option.type}
              </Typography>
            </Grid>
          </Grid>
        );
      }}
    />
  );
}
