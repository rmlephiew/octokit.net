﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octokit
{
    /// <summary>
    /// A client for GitHub's Repository Pages API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/pages/">Repository Pages API documentation</a> for more information.
    /// </remarks>
    public class RepositoryPagesClient : ApiClient, IRepositoryPagesClient
    {
        /// <summary>
        /// Initializes a new GitHub Repository Pages API client.
        /// </summary>
        /// <param name="apiConnection">An API connection.</param>
        public RepositoryPagesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets the page metadata for a given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#get-information-about-a-pages-site">API documentation</a> for more information.
        /// </remarks>
        public Task<Page> Get(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return ApiConnection.Get<Page>(ApiUrls.RepositoryPage(owner, name));
        }

        /// <summary>
        /// Gets the page metadata for a given repository
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#get-information-about-a-pages-site">API documentation</a> for more information.
        /// </remarks>
        public Task<Page> Get(int repositoryId)
        {
            return ApiConnection.Get<Page>(ApiUrls.RepositoryPage(repositoryId));
        }

        /// <summary>
        /// Gets all build metadata for a given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#list-pages-builds">API documentation</a> for more information.
        /// </remarks>
        public Task<IReadOnlyList<PagesBuild>> GetAll(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return GetAll(owner, name, ApiOptions.None);
        }

        /// <summary>
        /// Gets all build metadata for a given repository
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#list-pages-builds">API documentation</a> for more information.
        /// </remarks>
        public Task<IReadOnlyList<PagesBuild>> GetAll(int repositoryId)
        {
            return GetAll(repositoryId, ApiOptions.None);
        }

        /// <summary>
        /// Gets all build metadata for a given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="options">Options to change the API response</param>
        /// <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#list-pages-builds">API documentation</a> for more information.
        /// </remarks>
        public Task<IReadOnlyList<PagesBuild>> GetAll(string owner, string name, ApiOptions options)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(options, "options");

            var endpoint = ApiUrls.RepositoryPageBuilds(owner, name);
            return ApiConnection.GetAll<PagesBuild>(endpoint, options);
        }

        /// <summary>
        /// Gets all build metadata for a given repository
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="options">Options to change the API response</param>
        /// <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#list-pages-builds">API documentation</a> for more information.
        /// </remarks>
        public Task<IReadOnlyList<PagesBuild>> GetAll(int repositoryId, ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, "options");

            var endpoint = ApiUrls.RepositoryPageBuilds(repositoryId);
            return ApiConnection.GetAll<PagesBuild>(endpoint, options);
        }

        /// <summary>
        /// Gets the build metadata for the last build for a given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        ///  <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#list-latest-pages-build">API documentation</a> for more information.
        /// </remarks>
        public Task<PagesBuild> GetLatest(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return ApiConnection.Get<PagesBuild>(ApiUrls.RepositoryPageBuildsLatest(owner, name));
        }

        /// <summary>
        /// Gets the build metadata for the last build for a given repository
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        ///  <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/pages/#list-latest-pages-build">API documentation</a> for more information.
        /// </remarks>
        public Task<PagesBuild> GetLatest(int repositoryId)
        {
            return ApiConnection.Get<PagesBuild>(ApiUrls.RepositoryPageBuildsLatest(repositoryId));
        }
    }
}
