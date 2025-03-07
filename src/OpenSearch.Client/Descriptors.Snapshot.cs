/* SPDX-License-Identifier: Apache-2.0
*
* The OpenSearch Contributors require contributions made to
* this file be licensed under the Apache-2.0 license or a
* compatible open source license.
*/
/*
* Modifications Copyright OpenSearch Contributors. See
* GitHub history for details.
*
*  Licensed to Elasticsearch B.V. under one or more contributor
*  license agreements. See the NOTICE file distributed with
*  this work for additional information regarding copyright
*  ownership. Elasticsearch B.V. licenses this file to you under
*  the Apache License, Version 2.0 (the "License"); you may
*  not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
* 	http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing,
*  software distributed under the License is distributed on an
*  "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
*  KIND, either express or implied.  See the License for the
*  specific language governing permissions and limitations
*  under the License.
*/

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using OpenSearch.Net;
using OpenSearch.Net.Utf8Json;
using OpenSearch.Net.Specification.SnapshotApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace OpenSearch.Client
{
	///<summary>Descriptor for CleanupRepository <para></para></summary>
	public partial class CleanupRepositoryDescriptor : RequestDescriptorBase<CleanupRepositoryDescriptor, CleanupRepositoryRequestParameters, ICleanupRepositoryRequest>, ICleanupRepositoryRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotCleanupRepository;
		///<summary>/_snapshot/{repository}/_cleanup</summary>
		///<param name = "repository">this parameter is required</param>
		public CleanupRepositoryDescriptor(Name repository): base(r => r.Required("repository", repository))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected CleanupRepositoryDescriptor(): base()
		{
		}

		// values part of the url path
		Name ICleanupRepositoryRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public CleanupRepositoryDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public CleanupRepositoryDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Explicit operation timeout</summary>
		public CleanupRepositoryDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
	}

	///<summary>Descriptor for Clone <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class CloneSnapshotDescriptor : RequestDescriptorBase<CloneSnapshotDescriptor, CloneSnapshotRequestParameters, ICloneSnapshotRequest>, ICloneSnapshotRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotClone;
		///<summary>/_snapshot/{repository}/{snapshot}/_clone/{target_snapshot}</summary>
		///<param name = "repository">this parameter is required</param>
		///<param name = "snapshot">this parameter is required</param>
		///<param name = "targetSnapshot">this parameter is required</param>
		public CloneSnapshotDescriptor(Name repository, Name snapshot, Name targetSnapshot): base(r => r.Required("repository", repository).Required("snapshot", snapshot).Required("target_snapshot", targetSnapshot))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected CloneSnapshotDescriptor(): base()
		{
		}

		// values part of the url path
		Name ICloneSnapshotRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		Name ICloneSnapshotRequest.Snapshot => Self.RouteValues.Get<Name>("snapshot");
		Name ICloneSnapshotRequest.TargetSnapshot => Self.RouteValues.Get<Name>("target_snapshot");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public CloneSnapshotDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public CloneSnapshotDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
	}

	///<summary>Descriptor for Snapshot <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class SnapshotDescriptor : RequestDescriptorBase<SnapshotDescriptor, SnapshotRequestParameters, ISnapshotRequest>, ISnapshotRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotSnapshot;
		///<summary>/_snapshot/{repository}/{snapshot}</summary>
		///<param name = "repository">this parameter is required</param>
		///<param name = "snapshot">this parameter is required</param>
		public SnapshotDescriptor(Name repository, Name snapshot): base(r => r.Required("repository", repository).Required("snapshot", snapshot))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected SnapshotDescriptor(): base()
		{
		}

		// values part of the url path
		Name ISnapshotRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		Name ISnapshotRequest.Snapshot => Self.RouteValues.Get<Name>("snapshot");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public SnapshotDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public SnapshotDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Should this request wait until the operation has completed before returning</summary>
		public SnapshotDescriptor WaitForCompletion(bool? waitforcompletion = true) => Qs("wait_for_completion", waitforcompletion);
	}

	///<summary>Descriptor for CreateRepository <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class CreateRepositoryDescriptor : RequestDescriptorBase<CreateRepositoryDescriptor, CreateRepositoryRequestParameters, ICreateRepositoryRequest>, ICreateRepositoryRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotCreateRepository;
		///<summary>/_snapshot/{repository}</summary>
		///<param name = "repository">this parameter is required</param>
		public CreateRepositoryDescriptor(Name repository): base(r => r.Required("repository", repository))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected CreateRepositoryDescriptor(): base()
		{
		}

		// values part of the url path
		Name ICreateRepositoryRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public CreateRepositoryDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public CreateRepositoryDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Explicit operation timeout</summary>
		public CreateRepositoryDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Whether to verify the repository after creation</summary>
		public CreateRepositoryDescriptor Verify(bool? verify = true) => Qs("verify", verify);
	}

	///<summary>Descriptor for Delete <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class DeleteSnapshotDescriptor : RequestDescriptorBase<DeleteSnapshotDescriptor, DeleteSnapshotRequestParameters, IDeleteSnapshotRequest>, IDeleteSnapshotRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotDelete;
		///<summary>/_snapshot/{repository}/{snapshot}</summary>
		///<param name = "repository">this parameter is required</param>
		///<param name = "snapshot">this parameter is required</param>
		public DeleteSnapshotDescriptor(Name repository, Name snapshot): base(r => r.Required("repository", repository).Required("snapshot", snapshot))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteSnapshotDescriptor(): base()
		{
		}

		// values part of the url path
		Name IDeleteSnapshotRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		Name IDeleteSnapshotRequest.Snapshot => Self.RouteValues.Get<Name>("snapshot");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public DeleteSnapshotDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public DeleteSnapshotDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
	}

	///<summary>Descriptor for DeleteRepository <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class DeleteRepositoryDescriptor : RequestDescriptorBase<DeleteRepositoryDescriptor, DeleteRepositoryRequestParameters, IDeleteRepositoryRequest>, IDeleteRepositoryRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotDeleteRepository;
		///<summary>/_snapshot/{repository}</summary>
		///<param name = "repository">this parameter is required</param>
		public DeleteRepositoryDescriptor(Names repository): base(r => r.Required("repository", repository))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteRepositoryDescriptor(): base()
		{
		}

		// values part of the url path
		Names IDeleteRepositoryRequest.RepositoryName => Self.RouteValues.Get<Names>("repository");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public DeleteRepositoryDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public DeleteRepositoryDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Explicit operation timeout</summary>
		public DeleteRepositoryDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
	}

	///<summary>Descriptor for Get <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class GetSnapshotDescriptor : RequestDescriptorBase<GetSnapshotDescriptor, GetSnapshotRequestParameters, IGetSnapshotRequest>, IGetSnapshotRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotGet;
		///<summary>/_snapshot/{repository}/{snapshot}</summary>
		///<param name = "repository">this parameter is required</param>
		///<param name = "snapshot">this parameter is required</param>
		public GetSnapshotDescriptor(Name repository, Names snapshot): base(r => r.Required("repository", repository).Required("snapshot", snapshot))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected GetSnapshotDescriptor(): base()
		{
		}

		// values part of the url path
		Name IGetSnapshotRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		Names IGetSnapshotRequest.Snapshot => Self.RouteValues.Get<Names>("snapshot");
		// Request parameters
		///<summary>Whether to ignore unavailable snapshots, defaults to false which means a SnapshotMissingException is thrown</summary>
		public GetSnapshotDescriptor IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public GetSnapshotDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public GetSnapshotDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Whether to show verbose snapshot info or only show the basic info found in the repository index blob</summary>
		public GetSnapshotDescriptor Verbose(bool? verbose = true) => Qs("verbose", verbose);
	}

	///<summary>Descriptor for GetRepository <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class GetRepositoryDescriptor : RequestDescriptorBase<GetRepositoryDescriptor, GetRepositoryRequestParameters, IGetRepositoryRequest>, IGetRepositoryRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotGetRepository;
		///<summary>/_snapshot</summary>
		public GetRepositoryDescriptor(): base()
		{
		}

		///<summary>/_snapshot/{repository}</summary>
		///<param name = "repository">Optional, accepts null</param>
		public GetRepositoryDescriptor(Names repository): base(r => r.Optional("repository", repository))
		{
		}

		// values part of the url path
		Names IGetRepositoryRequest.RepositoryName => Self.RouteValues.Get<Names>("repository");
		///<summary>A comma-separated list of repository names</summary>
		public GetRepositoryDescriptor RepositoryName(Names repository) => Assign(repository, (a, v) => a.RouteValues.Optional("repository", v));
		// Request parameters
		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public GetRepositoryDescriptor Local(bool? local = true) => Qs("local", local);
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public GetRepositoryDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public GetRepositoryDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
	}

	///<summary>Descriptor for Restore <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class RestoreDescriptor : RequestDescriptorBase<RestoreDescriptor, RestoreRequestParameters, IRestoreRequest>, IRestoreRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotRestore;
		///<summary>/_snapshot/{repository}/{snapshot}/_restore</summary>
		///<param name = "repository">this parameter is required</param>
		///<param name = "snapshot">this parameter is required</param>
		public RestoreDescriptor(Name repository, Name snapshot): base(r => r.Required("repository", repository).Required("snapshot", snapshot))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected RestoreDescriptor(): base()
		{
		}

		// values part of the url path
		Name IRestoreRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		Name IRestoreRequest.Snapshot => Self.RouteValues.Get<Name>("snapshot");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public RestoreDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public RestoreDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Should this request wait until the operation has completed before returning</summary>
		public RestoreDescriptor WaitForCompletion(bool? waitforcompletion = true) => Qs("wait_for_completion", waitforcompletion);
	}

	///<summary>Descriptor for Status <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class SnapshotStatusDescriptor : RequestDescriptorBase<SnapshotStatusDescriptor, SnapshotStatusRequestParameters, ISnapshotStatusRequest>, ISnapshotStatusRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotStatus;
		///<summary>/_snapshot/_status</summary>
		public SnapshotStatusDescriptor(): base()
		{
		}

		///<summary>/_snapshot/{repository}/_status</summary>
		///<param name = "repository">Optional, accepts null</param>
		public SnapshotStatusDescriptor(Name repository): base(r => r.Optional("repository", repository))
		{
		}

		///<summary>/_snapshot/{repository}/{snapshot}/_status</summary>
		///<param name = "repository">Optional, accepts null</param>
		///<param name = "snapshot">Optional, accepts null</param>
		public SnapshotStatusDescriptor(Name repository, Names snapshot): base(r => r.Optional("repository", repository).Optional("snapshot", snapshot))
		{
		}

		// values part of the url path
		Name ISnapshotStatusRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		Names ISnapshotStatusRequest.Snapshot => Self.RouteValues.Get<Names>("snapshot");
		///<summary>A repository name</summary>
		public SnapshotStatusDescriptor RepositoryName(Name repository) => Assign(repository, (a, v) => a.RouteValues.Optional("repository", v));
		///<summary>A comma-separated list of snapshot names</summary>
		public SnapshotStatusDescriptor Snapshot(Names snapshot) => Assign(snapshot, (a, v) => a.RouteValues.Optional("snapshot", v));
		// Request parameters
		///<summary>Whether to ignore unavailable snapshots, defaults to false which means a SnapshotMissingException is thrown</summary>
		public SnapshotStatusDescriptor IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public SnapshotStatusDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public SnapshotStatusDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
	}

	///<summary>Descriptor for VerifyRepository <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class VerifyRepositoryDescriptor : RequestDescriptorBase<VerifyRepositoryDescriptor, VerifyRepositoryRequestParameters, IVerifyRepositoryRequest>, IVerifyRepositoryRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SnapshotVerifyRepository;
		///<summary>/_snapshot/{repository}/_verify</summary>
		///<param name = "repository">this parameter is required</param>
		public VerifyRepositoryDescriptor(Name repository): base(r => r.Required("repository", repository))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected VerifyRepositoryDescriptor(): base()
		{
		}

		// values part of the url path
		Name IVerifyRepositoryRequest.RepositoryName => Self.RouteValues.Get<Name>("repository");
		// Request parameters
		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public VerifyRepositoryDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public VerifyRepositoryDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Explicit operation timeout</summary>
		public VerifyRepositoryDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
	}
}
