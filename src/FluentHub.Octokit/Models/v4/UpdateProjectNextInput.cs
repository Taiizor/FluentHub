namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UpdateProjectNext
    /// </summary>
    public class UpdateProjectNextInput
    {
        /// <summary>
        /// The ID of the Project to update. This field is required.
        /// **Upcoming Change on 2022-10-01 UTC**
        /// **Description:** `projectId` will be removed. Follow the ProjectV2 guide at https://github.blog/changelog/2022-06-23-the-new-github-issues-june-23rd-update/, to find a suitable replacement.
        /// **Reason:** The `ProjectNext` API is deprecated in favour of the more capable `ProjectV2` API.
        /// </summary>
        public ID? ProjectId { get; set; }

        /// <summary>
        /// Set the title of the project.
        /// **Upcoming Change on 2022-10-01 UTC**
        /// **Description:** `title` will be removed. Follow the ProjectV2 guide at https://github.blog/changelog/2022-06-23-the-new-github-issues-june-23rd-update/, to find a suitable replacement.
        /// **Reason:** The `ProjectNext` API is deprecated in favour of the more capable `ProjectV2` API.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Set the readme description of the project.
        /// **Upcoming Change on 2022-10-01 UTC**
        /// **Description:** `description` will be removed. Follow the ProjectV2 guide at https://github.blog/changelog/2022-06-23-the-new-github-issues-june-23rd-update/, to find a suitable replacement.
        /// **Reason:** The `ProjectNext` API is deprecated in favour of the more capable `ProjectV2` API.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Set the short description of the project.
        /// **Upcoming Change on 2022-10-01 UTC**
        /// **Description:** `shortDescription` will be removed. Follow the ProjectV2 guide at https://github.blog/changelog/2022-06-23-the-new-github-issues-june-23rd-update/, to find a suitable replacement.
        /// **Reason:** The `ProjectNext` API is deprecated in favour of the more capable `ProjectV2` API.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Set the project to closed or open.
        /// **Upcoming Change on 2022-10-01 UTC**
        /// **Description:** `closed` will be removed. Follow the ProjectV2 guide at https://github.blog/changelog/2022-06-23-the-new-github-issues-june-23rd-update/, to find a suitable replacement.
        /// **Reason:** The `ProjectNext` API is deprecated in favour of the more capable `ProjectV2` API.
        /// </summary>
        public bool? Closed { get; set; }

        /// <summary>
        /// Set the project to public or private.
        /// **Upcoming Change on 2022-10-01 UTC**
        /// **Description:** `public` will be removed. Follow the ProjectV2 guide at https://github.blog/changelog/2022-06-23-the-new-github-issues-june-23rd-update/, to find a suitable replacement.
        /// **Reason:** The `ProjectNext` API is deprecated in favour of the more capable `ProjectV2` API.
        /// </summary>
        public bool? Public { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}