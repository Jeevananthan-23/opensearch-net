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

// ReSharper disable once CheckNamespace
namespace OpenSearch.Net.Specification.CatApi
{
	///<summary>Request options for Aliases <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-aliases/</para></summary>
	public class CatAliasesRequestParameters : RequestParameters<CatAliasesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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

	///<summary>Request options for Allocation <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-allocation/</para></summary>
	public class CatAllocationRequestParameters : RequestParameters<CatAllocationRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Count <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-count/</para></summary>
	public class CatCountRequestParameters : RequestParameters<CatCountRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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

	///<summary>Request options for Fielddata <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-field-data/</para></summary>
	public class CatFielddataRequestParameters : RequestParameters<CatFielddataRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>A comma-separated list of fields to return in the output</summary>
		public string[] Fields
		{
			get => Q<string[]>("fields");
			set => Q("fields", value);
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

	///<summary>Request options for Health <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-health/</para></summary>
	public class CatHealthRequestParameters : RequestParameters<CatHealthRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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

	///<summary>Request options for Help <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/index/</para></summary>
	public class CatHelpRequestParameters : RequestParameters<CatHelpRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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

	///<summary>Request options for Indices <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-indices/</para></summary>
	public class CatIndicesRequestParameters : RequestParameters<CatIndicesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Master <para>https://opensearch.org/docs/1.2/opensearch/rest-api/cat/cat-master/</para></summary>
	///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="CatClusterManagerRequestParameters"/> instead</remarks>
	public class CatMasterRequestParameters : RequestParameters<CatMasterRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for ClusterManager <para>https://opensearch.org/docs/2.0/opensearch/rest-api/cat/cat-cluster_manager/</para></summary>
	///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="CatMasterRequestParameters"/></remarks>
	public class CatClusterManagerRequestParameters : RequestParameters<CatClusterManagerRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		public TimeSpan ClusterManagerTimeout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for NodeAttributes <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-nodeattrs/</para></summary>
	public class CatNodeAttributesRequestParameters : RequestParameters<CatNodeAttributesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Nodes <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-nodes/</para></summary>
	public class CatNodesRequestParameters : RequestParameters<CatNodesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for PendingTasks <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-pending-tasks/</para></summary>
	public class CatPendingTasksRequestParameters : RequestParameters<CatPendingTasksRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Plugins <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-plugins/</para></summary>
	public class CatPluginsRequestParameters : RequestParameters<CatPluginsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Recovery <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-recovery/</para></summary>
	public class CatRecoveryRequestParameters : RequestParameters<CatRecoveryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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

		///<summary>Comma-separated list or wildcard expression of index names to limit the returned information</summary>
		public string[] IndexQueryString
		{
			get => Q<string[]>("index");
			set => Q("index", value);
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

	///<summary>Request options for Repositories <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-repositories/</para></summary>
	public class CatRepositoriesRequestParameters : RequestParameters<CatRepositoriesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Segments <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-segments/</para></summary>
	public class CatSegmentsRequestParameters : RequestParameters<CatSegmentsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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

	///<summary>Request options for Shards <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-shards/</para></summary>
	public class CatShardsRequestParameters : RequestParameters<CatShardsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Snapshots <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-snapshots/</para></summary>
	public class CatSnapshotsRequestParameters : RequestParameters<CatSnapshotsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for Tasks <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</para></summary>
	public class CatTasksRequestParameters : RequestParameters<CatTasksRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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

	///<summary>Request options for Templates <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-templates/</para></summary>
	public class CatTemplatesRequestParameters : RequestParameters<CatTemplatesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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

	///<summary>Request options for ThreadPool <para>https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-thread-pool/</para></summary>
	public class CatThreadPoolRequestParameters : RequestParameters<CatThreadPoolRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
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
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeSpanout"/> instead</remarks>
		public TimeSpan MasterTimeSpanout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeSpanout"/></remarks>
		public TimeSpan ClusterManagerTimeSpanout
		{
			get => Q<TimeSpan>("cluster_manager_timeout");
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
