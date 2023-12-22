import {
  fetchDelete, fetchGet, fetchPost, fetchPut
} from '../../Skolskjuts/api/apiUtils';
import { ResponseObject } from '../../Skolskjuts/api/responseTypes/responseObject';
import { DecisionCategory } from '../../Skolskjuts/interfaces';
import { DecisionCategoryUsage } from '../../Skolskjuts/interfaces/decisionCategory';

const baseUrl = 'api/Administration/DecisionCategories';

export async function getDecisionCategories(year: string): Promise<ResponseObject<DecisionCategory[]>> {
  return fetchGet(`${baseUrl}/${year}`);
}

export async function deleteDecisionCategory(year: string, categoryId: number): Promise<ResponseObject<string>> {
  return fetchDelete(`${baseUrl}/${year}/${categoryId}`);
}

export async function getDecisionCategory(year: string, categoryId: number): Promise<ResponseObject<DecisionCategory>> {
  return fetchGet(`${baseUrl}/${year}/${categoryId}`);
}

export async function addDecisionCategory(year: string, decisionCategory: DecisionCategory): Promise<ResponseObject<DecisionCategory>> {
  return fetchPost(`${baseUrl}/${year}`, decisionCategory);
}

export async function updateDecisionCategory(year: string, decisionCategory: DecisionCategory): Promise<ResponseObject<string>> {
  return fetchPut(`${baseUrl}/${year}`, decisionCategory);
}
// Hämta användningen av beslutskategorier
export async function getDecisionCategoriesUsage(year: string): Promise<ResponseObject<DecisionCategoryUsage[]>> {
  return fetchGet(`${baseUrl}/${year}/Usage`);
}