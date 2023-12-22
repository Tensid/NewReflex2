import { useClickOutside, useKeyPress } from '@sokigo-sbwebb/react';
import { useSetApplicationSubTitle } from '@sokigo-sbwebb/default-core';
import React, { useRef, useState, useEffect } from 'react';
import { ActionsDropdown, ActionsDropdownItem } from '@sokigo/components-react-bootstrap';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import {
  setCurrentYear, fetchYears, fetchMaxCount, fetchEpsg, fetchUsesDecisionAreas,
  fetchUsesSchoolAreas, fetchUsesPublicService, fetchUsesApplicationCompletion, fetchUseExternalPlanning, fetchUsesReportService, fetchExcelExportMenuItems, fetchUsesSearchTransports,
  fetchUseSmsService, fetchUsesBasicPlanning, fetchUsesTaxiExport, fetchUsesDashboard, fetchusesAutomationDecisionWizard
} from '../../features/base/baseSlice';
import { resetPupilFilter } from '../../features/pupilFilter/pupilFilterSlice';
import { setBadges } from '../../features/badgeViewer/badgeSlice';
import { resetPupilState } from '../../features/pupils/pupilsSlice';
import { resetCaseFilter } from '../../features/caseFilter/caseFilterSlice';
import { resetCaseState } from '../../features/cases/casesSlice';
import { resetTransportsState } from '../../features/transports/transportsSlice';
import { resetTransportFilter } from '../../features/transportFilter/transportFilterSlice';
import { resetOrganizationFilter } from '../../features/organizationFilter/organizationFilterSlice';
import { resetOrganizationState } from '../../features/organization/organizationSlice';
import { fetchLayers, fetchMapSettings } from '../../features/mapping/mapSettingsSlice';
import { setMapContentGroups } from '../../features/mapping/mapSlice';
import { fetchNotifications } from '../../features/notifications/notificationSlice';

export const SchoolYearSwitcher = ({ application, expanded }: any) => {
  const currentYear = useAppSelector((state) => state.base.currentYear);
  const yearsList = useAppSelector((state) => state.base.yearsList);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const setSubTitle = useSetApplicationSubTitle();
  const ref = useRef<HTMLDivElement | null>(null);
  const dispatch = useAppDispatch();

  useKeyPress('Escape', () => setDropdownOpen(false));
  useClickOutside(ref, () => setDropdownOpen(false));

  const onChangeYear = (year: string) => {
    // Reset Pupils
    dispatch(resetPupilState());
    dispatch(resetPupilFilter());
    // Reset Cases
    dispatch(resetCaseFilter());
    dispatch(resetCaseState());
    // Reset Organizations
    dispatch(resetOrganizationFilter());
    dispatch(resetOrganizationState());
    // Reset Transports
    dispatch(resetTransportsState());
    dispatch(resetTransportFilter());
    // Reset basic
    dispatch(setBadges([]));
    dispatch(setCurrentYear(year));
    dispatch(fetchEpsg(year));
    dispatch(fetchUsesBasicPlanning(year));
    dispatch(fetchUsesDashboard(year));
    dispatch(fetchUsesDecisionAreas(year));
    dispatch(fetchUsesSchoolAreas(year));
    dispatch(fetchusesAutomationDecisionWizard(year));
    dispatch(fetchUsesSearchTransports(year));
    dispatch(fetchUsesPublicService(year));
    dispatch(fetchUsesApplicationCompletion(year));
    dispatch(fetchUseExternalPlanning(year));
    dispatch(fetchUseSmsService(year));
    dispatch(fetchUsesReportService(year));
    dispatch(fetchUsesTaxiExport(year));
    dispatch(fetchExcelExportMenuItems(year));
    // Reset Map
    dispatch(setMapContentGroups([]));
  };

  // Initial Fetch
  useEffect(() => {
    dispatch(fetchYears());
    dispatch(fetchLayers());
    dispatch(fetchMapSettings());
    dispatch(fetchMaxCount());
  }, [dispatch]);

  useEffect(() => {
    if (currentYear) {
      setSubTitle(`Läsår ${currentYear}`);
      dispatch(setCurrentYear(currentYear));
      dispatch(fetchEpsg(currentYear));
      dispatch(fetchUsesBasicPlanning(currentYear));
      dispatch(fetchUsesDashboard(currentYear));
      dispatch(fetchUsesDecisionAreas(currentYear));
      dispatch(fetchUsesSchoolAreas(currentYear));
      dispatch(fetchusesAutomationDecisionWizard(currentYear));
      dispatch(fetchUsesPublicService(currentYear));
      dispatch(fetchUsesApplicationCompletion(currentYear));
      dispatch(fetchUsesSearchTransports(currentYear));
      dispatch(fetchUseExternalPlanning(currentYear));
      dispatch(fetchUseSmsService(currentYear));
      dispatch(fetchUsesReportService(currentYear));
      dispatch(fetchUsesTaxiExport(currentYear));
      dispatch(fetchExcelExportMenuItems(currentYear));
      dispatch(fetchNotifications(currentYear));
    }
    return () => setSubTitle('');
  }, [setSubTitle, dispatch, currentYear]);

  return (
    <>
      {expanded ? (
        <div style={{ height: 40 }}>
          <ActionsDropdown dropdownText="Visa läsår" icon={application.icon} block className='btn btn-ghost' >
            {yearsList.map((year: string) => (
              <ActionsDropdownItem key={year} onClick={() => onChangeYear(year)}>
                {year}
              </ActionsDropdownItem>
            ))}
          </ActionsDropdown>
        </div>
      ) : (
        <ActionsDropdown aria-label='Visa läsår' icon={application.icon} className='btn btn-ghost' tooltipText="Visa läsår">
          {yearsList.map((year: string) => (
            <ActionsDropdownItem
              key={year}
              onClick={() => {
                if (currentYear !== year) {
                  onChangeYear(year);
                }
              }}
              className={`dropdown-item cursor-pointer ${currentYear === year ? 'active' : ''}`}
            >
              {year}
            </ActionsDropdownItem>
          ))}
        </ActionsDropdown>
      )}
    </>
  );
};