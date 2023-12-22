import React from 'react';
import { HelpLink } from '@sokigo-sbwebb/default-components';
import { useLocation } from 'react-router-dom';

// This help is for main views only, not modals or popups
export function getSection(pathname: string) {
  switch (pathname) {
    case '/skolskjuts/pupils':
      return 'pupils';
    case '/skolskjuts/map':
      return 'map';
    case '/skolskjuts/cases':
      return 'cases';
    case '/transport-planning':
      return 'transportPlanning';
    case '/skolskjuts/messageCenter':
      return 'messageCenter';
    case '/skolskjuts/transports':
      return 'transports';
    case '/skolskjuts/transportStops':
      return 'transportStops';
    case '/skolskjuts/schools':
      return 'schools';
    case '/skolskjuts':
      return 'home';
    case '/administration/decision-categories':
      return 'decision-categories';
    case '/administration/elevkortsmallar':
      return 'elevkortsmallar';
    case '/administration/database-files':
      return 'database-files';
    case '/administration/categories-and-packages':
      return 'categories-and-packages';
    case '/administration/phrases':
      return 'phrases';
    case '/maintenance/add-pupil':
      return 'addPupil';
    case '/maintenance/add-school':
      return 'addSchool';
    case '/maintenance/add-grade':
      return 'addGrade';
    case '/maintenance/add-class':
      return 'addClass';
    case '/maintenance/deletion':
      return 'deletion';
    case '/maintenance/import-pupils':
      return 'importPupils';
    case '/maintenance/event-logs':
      return 'eventLogs';
    case '/system-settings/edit-tags':
      return 'tagusage';
    case '/system-settings/closed-roads':
      return 'closedRoads';
    case '/system-settings/manage-roads':
      return 'manageRoads';
    case '/system-settings/map':
      return 'map';
    case '/system-settings/metadata-groups':
      return 'metaDataGroups';
    case '/system-settings/groups':
      return 'groups';
    case '/system-settings/decisionRules':
      return 'decisionrules';
    case '/system-settings/rules':
      return 'otherrules';
    case '/system-settings/excel-exports':
      return 'excelExports';
    case '/system-settings/school-forms':
      return 'schoolForms';
    case '/system-settings/transport-competencies':
      return 'transportCompetencies';
    case '/system-settings/agents':
      return 'agents';
    case '/system-settings/misc-settings':
      return 'miscSettings';
    case '/system-settings/pupilregister':
      return 'pupilRegister';
    case '/system-settings/areas':
      return 'areas';
    case '/system-settings/users':
      return 'users';
    default:
      if (pathname.includes('/skolskjuts/pupils')) return 'pupil';
      if (pathname.includes('/skolskjuts/transports')) return 'trip';
      if (pathname.includes('/skolskjuts/transportStops')) return 'transportStop';
      if (pathname.includes('/skolskjuts/schools/grade')) return 'grade';
      if (pathname.includes('/skolskjuts/schools/class')) return 'class';
      if (pathname.includes('/skolskjuts/schools')) return 'school';
      return 'mainArticle';
  }
}

export function Help({ expanded }: { expanded: boolean }) {
  const { pathname } = useLocation();
  const section = getSection(pathname);

  return (
    <div className="d-flex align-items-center" style={{ width: !expanded ? 40 : '100%' }}>
      <HelpLink tooltipText="Hjälp" aria-label="Hjälp" section={section} block>
        {expanded ? 'Hjälp' : null}
      </HelpLink>
    </div>
  );
}

export default Help;