import { useAppSelector } from '../../app/hooks';

export function NavbarSchoolYear({ expanded }: { expanded: boolean }) {
  const currentYear = useAppSelector((state) => state.base.currentYear);

  if (expanded) return null;
  return (
    <h4 className='align-self-center pl-2'>
      {'Reflex'}<span className='text-muted'> - {currentYear}</span>
    </h4>
  );
}

export default NavbarSchoolYear;