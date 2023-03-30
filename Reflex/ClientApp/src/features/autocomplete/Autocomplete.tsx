import { ChangeEvent, MutableRefObject, useEffect, useRef, useState } from 'react';
import SearchIcon from '@mui/icons-material/Search';
import MaterialAutocomplete from '@mui/material/Autocomplete';
import Button from '@mui/material/Button';
import CircularProgress from '@mui/material/CircularProgress';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import match from 'autosuggest-highlight/match';
import parse from 'autosuggest-highlight/parse';
import { SearchResult, search } from '../../api/api';

interface AutocompleteProps {
  onSelectCallback: (data: SearchResult) => void;
  searchResult: SearchResult;
}

export default function Autocomplete({ onSelectCallback, searchResult }: AutocompleteProps) {
  const [inputValue, setInputValue] = useState(searchResult?.displayName || searchResult?.value || '');
  const [options, setOptions] = useState<SearchResult[]>([]);
  const [loading, setLoading] = useState(false);
  const inputRef: MutableRefObject<HTMLInputElement | undefined> = useRef<HTMLInputElement>();

  async function getData(val: string) {
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

  useEffect(() => {
    (async () => {
      const query = searchResult?.displayName || searchResult?.value;
      if (query) {
        const data = await search(query);
        setOptions(data);
      }
    })();
  }, [searchResult]);

  return (
    <Grid container>
      <Grid item>
        <MaterialAutocomplete
          openOnFocus
          style={{ width: 300 }}
          getOptionLabel={(option) => (typeof option === 'string' ? option : option.displayName)}
          filterOptions={(x) => x}
          options={options}
          freeSolo
          autoComplete
          includeInputInList
          loadingText="Hämtar"
          defaultValue={searchResult}
          loading={loading}
          onChange={async (_event: any, newInputValue: any, reason: any) => {
            if (newInputValue && reason === "selectOption")
              onSelectCallback(newInputValue);
            else if (newInputValue && reason === "createOption") {
              await getData(inputValue);
              inputRef.current?.blur();
              inputRef.current?.focus();
            }
          }}
          renderInput={(params) => (
            <TextField
              {...params}
              inputRef={input => {
                if (input)
                  inputRef.current = input;
              }}
              variant="outlined"
              fullWidth
              onChange={handleChange}
              InputProps={{
                ...params.InputProps,
                endAdornment: (
                  <>
                    {loading && <CircularProgress color="inherit" size={20} />}
                    {params.InputProps.endAdornment}
                  </>
                )
              }}
            />
          )}
          renderOption={(props, option) => {
            let matches = match(option.displayName, inputValue);

            if (matches?.length < 1 && option.displayName && inputValue)
              matches = customMatch(option.displayName, inputValue);

            const parts = parse(
              option.displayName,
              matches
            );

            return (
              <Grid container alignItems="center"  {...props as any}>
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
      </Grid>
      <Grid item style={{ display: "flex" }}>
        <Button
          variant="contained"
          startIcon={<SearchIcon />}
          aria-label="Sök"
          onClick={async () => {
            await getData(inputValue);
            inputRef.current?.focus();
          }}
        >
          Sök
        </Button>
      </Grid>
    </Grid>
  );
}
