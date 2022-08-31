using System.Collections.Generic;

namespace TherapistDatabase.Models
{
    public interface IProviderRepository
    {
        public IEnumerable<Provider> GetAllProviders();
        public Provider              GetProvider(int employeeID);
        public void                  AddProvider(Provider provider);
        public void                  UpdateProvider(Provider provider);
        public void                  DeleteProvider(int employeeID);

        //TODO: implement this:
        //public IEnumerable<Therapist> GetTherapistsBySpecialty(SpecialtyList spec);
    }
}
