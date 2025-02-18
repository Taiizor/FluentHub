namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of DeletePullRequestReview
    /// </summary>
    public class DeletePullRequestReviewInput
    {
        /// <summary>
        /// The Node ID of the pull request review to delete.
        /// </summary>
        public ID PullRequestReviewId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}