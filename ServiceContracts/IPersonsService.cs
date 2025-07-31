using System;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Perosn entity
    /// </summary>
    public interface IPersonsService
    {
        /// <summary>
        /// Addds a new person into the list of persons
        /// </summary>
        /// <param name="personAddRequest">Person to add</param>
        /// <returns>Returns the same person details, along with newly generated PersonID</returns>
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);


        /// <summary>
        /// Returns all persons
        /// </summary>
        /// <returns>Returns a list of objects of PersonResponse type</returns>
        List<PersonResponse> GetAllPersons();


        /// <summary>
        /// Returns the person object based on the given person id
        /// </summary>
        /// <param name="personID"></param>
        /// <returns>Returns matching person object</returns>
        PersonResponse? GetPersonByPersonID(Guid? personID);


        /// <summary>
        /// Returns all person objects that matches with the given search field and search string
        /// </summary>
        /// <param name="searchBy">Search field to search</param>
        /// <param name="searchString">Search string to search</param>
        /// <returns></returns>
        List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString);

        List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);
        /// <summary>
        /// Updates the specified person details based on the given person ID
        /// </summary>
        /// <param name="personUpdateRequest">Person details to update</param>
        /// <returns>Returns the person response object after updation</returns>
        PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);

        /// <summary>
        /// Deletes a person based on the given person id
        /// </summary>
        /// <param name="PersonID">PersonID to delete</param>
        /// <returns>Returns true, if the deletion is successful; otherwise false</returns>
        bool DeletePerson(Guid? personID);
        /// <summary>
        /// Returns person as CSV
        /// </summary>
        /// <returns>REturns the memory stream with CSV data</returns>
        Task<MemoryStream> GetPersonsCSV();

    }
}