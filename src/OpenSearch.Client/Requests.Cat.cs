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
using System.Runtime.Serialization;
using OpenSearch.Net;
using OpenSearch.Net.Utf8Json;
using OpenSearch.Net.Specification.CatApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace OpenSearch.Client
{
	[InterfaceDataContract]
	public partial interface ICatAliasesRequest : IRequest<CatAliasesRequestParameters>
	{
		[IgnoreDataMember]
		Names Name
		{
			get;
		}
	}

	///<summary>Request for Aliases <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-aliases/</para></summary>
	public partial class CatAliasesRequest : PlainRequestBase<CatAliasesRequestParameters>, ICatAliasesRequest
	{
		protected ICatAliasesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatAliases;
		///<summary>/_cat/aliases</summary>
		public CatAliasesRequest(): base()
		{
		}

		///<summary>/_cat/aliases/{name}</summary>
		///<param name = "name">Optional, accepts null</param>
		public CatAliasesRequest(Names name): base(r => r.Optional("name", name))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names ICatAliasesRequest.Name => Self.RouteValues.Get<Names>("name");
		// Request parameters
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatAllocationRequest : IRequest<CatAllocationRequestParameters>
	{
		[IgnoreDataMember]
		NodeIds NodeId
		{
			get;
		}
	}

	///<summary>Request for Allocation <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-allocation/</para></summary>
	public partial class CatAllocationRequest : PlainRequestBase<CatAllocationRequestParameters>, ICatAllocationRequest
	{
		protected ICatAllocationRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatAllocation;
		///<summary>/_cat/allocation</summary>
		public CatAllocationRequest(): base()
		{
		}

		///<summary>/_cat/allocation/{node_id}</summary>
		///<param name = "nodeId">Optional, accepts null</param>
		public CatAllocationRequest(NodeIds nodeId): base(r => r.Optional("node_id", nodeId))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		NodeIds ICatAllocationRequest.NodeId => Self.RouteValues.Get<NodeIds>("node_id");
		// Request parameters
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatCountRequest : IRequest<CatCountRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	///<summary>Request for Count <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-count/</para></summary>
	public partial class CatCountRequest : PlainRequestBase<CatCountRequestParameters>, ICatCountRequest
	{
		protected ICatCountRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatCount;
		///<summary>/_cat/count</summary>
		public CatCountRequest(): base()
		{
		}

		///<summary>/_cat/count/{index}</summary>
		///<param name = "index">Optional, accepts null</param>
		public CatCountRequest(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices ICatCountRequest.Index => Self.RouteValues.Get<Indices>("index");
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatFielddataRequest : IRequest<CatFielddataRequestParameters>
	{
		[IgnoreDataMember]
		Fields Fields
		{
			get;
		}
	}

	///<summary>Request for Fielddata <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-field-data/</para></summary>
	public partial class CatFielddataRequest : PlainRequestBase<CatFielddataRequestParameters>, ICatFielddataRequest
	{
		protected ICatFielddataRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatFielddata;
		///<summary>/_cat/fielddata</summary>
		public CatFielddataRequest(): base()
		{
		}

		///<summary>/_cat/fielddata/{fields}</summary>
		///<param name = "fields">Optional, accepts null</param>
		public CatFielddataRequest(Fields fields): base(r => r.Optional("fields", fields))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Fields ICatFielddataRequest.Fields => Self.RouteValues.Get<Fields>("fields");
		// Request parameters
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatHealthRequest : IRequest<CatHealthRequestParameters>
	{
	}

	///<summary>Request for Health <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-health/</para></summary>
	public partial class CatHealthRequest : PlainRequestBase<CatHealthRequestParameters>, ICatHealthRequest
	{
		protected ICatHealthRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatHealth;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Set to false to disable timestamping</summary>
		public bool? IncludeTimestamp
		{
			get => Q<bool? >("ts");
			set => Q("ts", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatHelpRequest : IRequest<CatHelpRequestParameters>
	{
	}

	///<summary>Request for Help <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/index/</para></summary>
	public partial class CatHelpRequest : PlainRequestBase<CatHelpRequestParameters>, ICatHelpRequest
	{
		protected ICatHelpRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatHelp;
		// values part of the url path
		// Request parameters
		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatIndicesRequest : IRequest<CatIndicesRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	///<summary>Request for Indices <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-indices/</para></summary>
	public partial class CatIndicesRequest : PlainRequestBase<CatIndicesRequestParameters>, ICatIndicesRequest
	{
		protected ICatIndicesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatIndices;
		///<summary>/_cat/indices</summary>
		public CatIndicesRequest(): base()
		{
		}

		///<summary>/_cat/indices/{index}</summary>
		///<param name = "index">Optional, accepts null</param>
		public CatIndicesRequest(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices ICatIndicesRequest.Index => Self.RouteValues.Get<Indices>("index");
		// Request parameters
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>A health status ("green", "yellow", or "red" to filter only indices matching the specified health status</summary>
		public Health? Health
		{
			get => Q<Health? >("health");
			set => Q("health", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>If set to true segment stats will include stats for segments that are not currently loaded into memory</summary>
		public bool? IncludeUnloadedSegments
		{
			get => Q<bool? >("include_unloaded_segments");
			set => Q("include_unloaded_segments", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Set to true to return stats only for primary shards</summary>
		public bool? Pri
		{
			get => Q<bool? >("pri");
			set => Q("pri", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatMasterRequest : IRequest<CatMasterRequestParameters>
	{
	}

	///<summary>Request for Master <para>https://opensearch.org/docs/1.2/opensearch/rest-api/cat/cat-master/</para></summary>
	///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="CatClusterManagerRequest"/> instead</remarks>
	public partial class CatMasterRequest : PlainRequestBase<CatMasterRequestParameters>, ICatMasterRequest
	{
		protected ICatMasterRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatMaster;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatClusterManagerRequest : IRequest<CatClusterManagerRequestParameters>
	{
	}

	///<summary>Request for ClusterManager <para>https://opensearch.org/docs/1.2/opensearch/rest-api/cat/cat-master/</para></summary>
	///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="CatMasterRequest"/></remarks>
	public partial class CatClusterManagerRequest : PlainRequestBase<CatClusterManagerRequestParameters>, ICatClusterManagerRequest
	{
		protected ICatClusterManagerRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatClusterManager;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatNodeAttributesRequest : IRequest<CatNodeAttributesRequestParameters>
	{
	}

	///<summary>Request for NodeAttributes <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-nodeattrs/</para></summary>
	public partial class CatNodeAttributesRequest : PlainRequestBase<CatNodeAttributesRequestParameters>, ICatNodeAttributesRequest
	{
		protected ICatNodeAttributesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatNodeAttributes;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatNodesRequest : IRequest<CatNodesRequestParameters>
	{
	}

	///<summary>Request for Nodes <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-nodes/</para></summary>
	public partial class CatNodesRequest : PlainRequestBase<CatNodesRequestParameters>, ICatNodesRequest
	{
		protected ICatNodesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatNodes;
		// values part of the url path
		// Request parameters
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Return the full node ID instead of the shortened version (default: false)</summary>
		public bool? FullId
		{
			get => Q<bool? >("full_id");
			set => Q("full_id", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatPendingTasksRequest : IRequest<CatPendingTasksRequestParameters>
	{
	}

	///<summary>Request for PendingTasks <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-pending-tasks/</para></summary>
	public partial class CatPendingTasksRequest : PlainRequestBase<CatPendingTasksRequestParameters>, ICatPendingTasksRequest
	{
		protected ICatPendingTasksRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatPendingTasks;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatPluginsRequest : IRequest<CatPluginsRequestParameters>
	{
	}

	///<summary>Request for Plugins <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-plugins/</para></summary>
	public partial class CatPluginsRequest : PlainRequestBase<CatPluginsRequestParameters>, ICatPluginsRequest
	{
		protected ICatPluginsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatPlugins;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Include bootstrap plugins in the response</summary>
		public bool? IncludeBootstrap
		{
			get => Q<bool? >("include_bootstrap");
			set => Q("include_bootstrap", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatRecoveryRequest : IRequest<CatRecoveryRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	///<summary>Request for Recovery <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-recovery/</para></summary>
	public partial class CatRecoveryRequest : PlainRequestBase<CatRecoveryRequestParameters>, ICatRecoveryRequest
	{
		protected ICatRecoveryRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatRecovery;
		///<summary>/_cat/recovery</summary>
		public CatRecoveryRequest(): base()
		{
		}

		///<summary>/_cat/recovery/{index}</summary>
		///<param name = "index">Optional, accepts null</param>
		public CatRecoveryRequest(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices ICatRecoveryRequest.Index => Self.RouteValues.Get<Indices>("index");
		// Request parameters
		///<summary>If `true`, the response only includes ongoing shard recoveries</summary>
		public bool? ActiveOnly
		{
			get => Q<bool? >("active_only");
			set => Q("active_only", value);
		}

		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>If `true`, the response includes detailed information about shard recoveries</summary>
		public bool? Detailed
		{
			get => Q<bool? >("detailed");
			set => Q("detailed", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatRepositoriesRequest : IRequest<CatRepositoriesRequestParameters>
	{
	}

	///<summary>Request for Repositories <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-repositories/</para></summary>
	public partial class CatRepositoriesRequest : PlainRequestBase<CatRepositoriesRequestParameters>, ICatRepositoriesRequest
	{
		protected ICatRepositoriesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatRepositories;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatSegmentsRequest : IRequest<CatSegmentsRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	///<summary>Request for Segments <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-segments/</para></summary>
	public partial class CatSegmentsRequest : PlainRequestBase<CatSegmentsRequestParameters>, ICatSegmentsRequest
	{
		protected ICatSegmentsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatSegments;
		///<summary>/_cat/segments</summary>
		public CatSegmentsRequest(): base()
		{
		}

		///<summary>/_cat/segments/{index}</summary>
		///<param name = "index">Optional, accepts null</param>
		public CatSegmentsRequest(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices ICatSegmentsRequest.Index => Self.RouteValues.Get<Indices>("index");
		// Request parameters
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatShardsRequest : IRequest<CatShardsRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	///<summary>Request for Shards <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-shards/</para></summary>
	public partial class CatShardsRequest : PlainRequestBase<CatShardsRequestParameters>, ICatShardsRequest
	{
		protected ICatShardsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatShards;
		///<summary>/_cat/shards</summary>
		public CatShardsRequest(): base()
		{
		}

		///<summary>/_cat/shards/{index}</summary>
		///<param name = "index">Optional, accepts null</param>
		public CatShardsRequest(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices ICatShardsRequest.Index => Self.RouteValues.Get<Indices>("index");
		// Request parameters
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatSnapshotsRequest : IRequest<CatSnapshotsRequestParameters>
	{
		[IgnoreDataMember]
		Names RepositoryName
		{
			get;
		}
	}

	///<summary>Request for Snapshots <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public partial class CatSnapshotsRequest : PlainRequestBase<CatSnapshotsRequestParameters>, ICatSnapshotsRequest
	{
		protected ICatSnapshotsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatSnapshots;
		///<summary>/_cat/snapshots</summary>
		public CatSnapshotsRequest(): base()
		{
		}

		///<summary>/_cat/snapshots/{repository}</summary>
		///<param name = "repository">Optional, accepts null</param>
		public CatSnapshotsRequest(Names repository): base(r => r.Optional("repository", repository))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names ICatSnapshotsRequest.RepositoryName => Self.RouteValues.Get<Names>("repository");
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Set to true to ignore unavailable snapshots</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatTasksRequest : IRequest<CatTasksRequestParameters>
	{
	}

	///<summary>Request for Tasks <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</para></summary>
	///<remarks>Note: Experimental within the OpenSearch server, this functionality is experimental and may be changed or removed completely in a future release. OpenSearch will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features.</remarks>
	public partial class CatTasksRequest : PlainRequestBase<CatTasksRequestParameters>, ICatTasksRequest
	{
		protected ICatTasksRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatTasks;
		// values part of the url path
		// Request parameters
		///<summary>A comma-separated list of actions that should be returned. Leave empty to return all.</summary>
		public string[] Actions
		{
			get => Q<string[]>("actions");
			set => Q("actions", value);
		}

		///<summary>Return detailed task information (default: false)</summary>
		public bool? Detailed
		{
			get => Q<bool? >("detailed");
			set => Q("detailed", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>
		/// A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you're
		/// connecting to, leave empty to get information from all nodes
		///</summary>
		public string[] Nodes
		{
			get => Q<string[]>("nodes");
			set => Q("nodes", value);
		}

		///<summary>Return tasks with specified parent task id (node_id:task_number). Set to -1 to return all.</summary>
		public string ParentTaskId
		{
			get => Q<string>("parent_task_id");
			set => Q("parent_task_id", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatTemplatesRequest : IRequest<CatTemplatesRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for Templates <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-templates/</para></summary>
	public partial class CatTemplatesRequest : PlainRequestBase<CatTemplatesRequestParameters>, ICatTemplatesRequest
	{
		protected ICatTemplatesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatTemplates;
		///<summary>/_cat/templates</summary>
		public CatTemplatesRequest(): base()
		{
		}

		///<summary>/_cat/templates/{name}</summary>
		///<param name = "name">Optional, accepts null</param>
		public CatTemplatesRequest(Name name): base(r => r.Optional("name", name))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name ICatTemplatesRequest.Name => Self.RouteValues.Get<Name>("name");
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	[InterfaceDataContract]
	public partial interface ICatThreadPoolRequest : IRequest<CatThreadPoolRequestParameters>
	{
		[IgnoreDataMember]
		Names ThreadPoolPatterns
		{
			get;
		}
	}

	///<summary>Request for ThreadPool <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-thread-pool/</para></summary>
	public partial class CatThreadPoolRequest : PlainRequestBase<CatThreadPoolRequestParameters>, ICatThreadPoolRequest
	{
		protected ICatThreadPoolRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CatThreadPool;
		///<summary>/_cat/thread_pool</summary>
		public CatThreadPoolRequest(): base()
		{
		}

		///<summary>/_cat/thread_pool/{thread_pool_patterns}</summary>
		///<param name = "threadPoolPatterns">Optional, accepts null</param>
		public CatThreadPoolRequest(Names threadPoolPatterns): base(r => r.Optional("thread_pool_patterns", threadPoolPatterns))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names ICatThreadPoolRequest.ThreadPoolPatterns => Self.RouteValues.Get<Names>("thread_pool_patterns");
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set
			{
				Q("format", value);
				SetAcceptHeader(value);
			}
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public Time MasterTimeout
		{
			get => Q<Time>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public Time ClusterManagerTimeout
		{
			get => Q<Time>("cluster_manager_timeout");
			set => Q("cluster_manager_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}
}
