import {
  fetchDelete, fetchGet, fetchPost, fetchPut
} from '../../Skolskjuts/api/apiUtils';
import { ResponseObject } from '../../Skolskjuts/api/responseTypes/responseObject';
import { Phrase, PhraseBase } from '../../Skolskjuts/interfaces/phrase';
import { PhraseUsage } from '../../Skolskjuts/interfaces/phraseUsage';

const baseUrl = 'api/Administration/phrases';

export async function getPhrases(year: string): Promise<ResponseObject<Phrase[]>> {
  return fetchGet(`${baseUrl}/${year}`);
}

export async function getPhrasesUsage(year: string): Promise<ResponseObject<PhraseUsage[]>> {
  return fetchGet(`${baseUrl}/${year}/Usage`);
}

export async function addPhrase(year: string, phrase: PhraseBase): Promise<ResponseObject<Phrase>> {
  return fetchPost(`${baseUrl}/${year}`, phrase);
}

export async function updatePhrase(year: string, phrase: PhraseBase): Promise<ResponseObject<Phrase>> {
  return fetchPut(`${baseUrl}/${year}`, phrase);
}

export async function deletePhrase(year: string, id: number, forceDelete: boolean = false): Promise<ResponseObject<string>> {
  return fetchDelete(`${baseUrl}/${year}/${id}?forceDelete=${forceDelete}`);
}