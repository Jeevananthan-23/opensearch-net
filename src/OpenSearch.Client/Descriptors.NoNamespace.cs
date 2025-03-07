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

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace OpenSearch.Client
{
	///<summary>Descriptor for Bulk <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/bulk/</para></summary>
	public partial class BulkDescriptor : RequestDescriptorBase<BulkDescriptor, BulkRequestParameters, IBulkRequest>, IBulkRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceBulk;
		///<summary>/_bulk</summary>
		public BulkDescriptor(): base()
		{
		}

		///<summary>/{index}/_bulk</summary>
		///<param name = "index">Optional, accepts null</param>
		public BulkDescriptor(IndexName index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		IndexName IBulkRequest.Index => Self.RouteValues.Get<IndexName>("index");
		///<summary>Default index for items which don't provide one</summary>
		public BulkDescriptor Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public BulkDescriptor Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (IndexName)v));
		// Request parameters
		///<summary>The pipeline id to preprocess incoming documents with</summary>
		public BulkDescriptor Pipeline(string pipeline) => Qs("pipeline", pipeline);
		///<summary>If `true` then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this operation visible to search, if `false` (the default) then do nothing with refreshes.</summary>
		public BulkDescriptor Refresh(Refresh? refresh) => Qs("refresh", refresh);
		///<summary>Sets require_alias for all incoming documents. Defaults to unset (false)</summary>
		public BulkDescriptor RequireAlias(bool? requirealias = true) => Qs("require_alias", requirealias);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OpenSearch.Client will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public BulkDescriptor Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public BulkDescriptor SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>Default list of fields to exclude from the returned _source field, can be overridden on each sub-request</summary>
		public BulkDescriptor SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>Default list of fields to exclude from the returned _source field, can be overridden on each sub-request</summary>
		public BulkDescriptor SourceExcludes<T>(params Expression<Func<T, object>>[] fields)
			where T : class => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>Default list of fields to extract and return from the _source field, can be overridden on each sub-request</summary>
		public BulkDescriptor SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>Default list of fields to extract and return from the _source field, can be overridden on each sub-request</summary>
		public BulkDescriptor SourceIncludes<T>(params Expression<Func<T, object>>[] fields)
			where T : class => Qs("_source_includes", fields?.Select(e => (Field)e));
		///<summary>Explicit operation timeout</summary>
		public BulkDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Default document type for items which don't provide one</summary>
		public BulkDescriptor TypeQueryString(string typequerystring) => Qs("type", typequerystring);
		///<summary>Sets the number of shard copies that must be active before proceeding with the bulk operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public BulkDescriptor WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
	}

	///<summary>Descriptor for ClearScroll <para>https://opensearch.org/docs/latest/opensearch/rest-api/scroll/</para></summary>
	public partial class ClearScrollDescriptor : RequestDescriptorBase<ClearScrollDescriptor, ClearScrollRequestParameters, IClearScrollRequest>, IClearScrollRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceClearScroll;
	// values part of the url path
	// Request parameters
	}

	///<summary>Descriptor for Count <para>https://opensearch.org/docs/latest/opensearch/rest-api/count/</para></summary>
	public partial class CountDescriptor<TDocument> : RequestDescriptorBase<CountDescriptor<TDocument>, CountRequestParameters, ICountRequest<TDocument>>, ICountRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceCount;
		///<summary>/{index}/_count</summary>
		public CountDescriptor(): this(typeof(TDocument))
		{
		}

		///<summary>/{index}/_count</summary>
		///<param name = "index">Optional, accepts null</param>
		public CountDescriptor(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		Indices ICountRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of indices to restrict the results</summary>
		public CountDescriptor<TDocument> Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public CountDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public CountDescriptor<TDocument> AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have been specified)</summary>
		public CountDescriptor<TDocument> AllowNoIndices(bool? allownoindices = true) => Qs("allow_no_indices", allownoindices);
		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public CountDescriptor<TDocument> AnalyzeWildcard(bool? analyzewildcard = true) => Qs("analyze_wildcard", analyzewildcard);
		///<summary>The analyzer to use for the query string</summary>
		public CountDescriptor<TDocument> Analyzer(string analyzer) => Qs("analyzer", analyzer);
		///<summary>The default operator for query string query (AND or OR)</summary>
		public CountDescriptor<TDocument> DefaultOperator(DefaultOperator? defaultoperator) => Qs("default_operator", defaultoperator);
		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public CountDescriptor<TDocument> Df(string df) => Qs("df", df);
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public CountDescriptor<TDocument> ExpandWildcards(ExpandWildcards? expandwildcards) => Qs("expand_wildcards", expandwildcards);
		///<summary>Whether specified concrete, expanded or aliased indices should be ignored when throttled</summary>
		public CountDescriptor<TDocument> IgnoreThrottled(bool? ignorethrottled = true) => Qs("ignore_throttled", ignorethrottled);
		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public CountDescriptor<TDocument> IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public CountDescriptor<TDocument> Lenient(bool? lenient = true) => Qs("lenient", lenient);
		///<summary>Include only documents with a specific `_score` value in the result</summary>
		public CountDescriptor<TDocument> MinScore(double? minscore) => Qs("min_score", minscore);
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public CountDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Query in the Lucene query string syntax</summary>
		public CountDescriptor<TDocument> QueryOnQueryString(string queryonquerystring) => Qs("q", queryonquerystring);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OpenSearch.Client will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public CountDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>The maximum count for each shard, upon reaching which the query execution will terminate early</summary>
		public CountDescriptor<TDocument> TerminateAfter(long? terminateafter) => Qs("terminate_after", terminateafter);
	}

	///<summary>Descriptor for Create <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/index-document/</para></summary>
	public partial class CreateDescriptor<TDocument> : RequestDescriptorBase<CreateDescriptor<TDocument>, CreateRequestParameters, ICreateRequest<TDocument>>, ICreateRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceCreate;
		///<summary>/{index}/_create/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public CreateDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_create/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public CreateDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_create/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public CreateDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Client.Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected CreateDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName ICreateRequest<TDocument>.Index => Self.RouteValues.Get<IndexName>("index");
		Id ICreateRequest<TDocument>.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public CreateDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public CreateDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>The pipeline id to preprocess incoming documents with</summary>
		public CreateDescriptor<TDocument> Pipeline(string pipeline) => Qs("pipeline", pipeline);
		///<summary>If `true` then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this operation visible to search, if `false` (the default) then do nothing with refreshes.</summary>
		public CreateDescriptor<TDocument> Refresh(Refresh? refresh) => Qs("refresh", refresh);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OpenSearch.Client will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public CreateDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Explicit operation timeout</summary>
		public CreateDescriptor<TDocument> Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Explicit version number for concurrency control</summary>
		public CreateDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public CreateDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
		///<summary>Sets the number of shard copies that must be active before proceeding with the index operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public CreateDescriptor<TDocument> WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
	}

	///<summary>Descriptor for Delete <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/delete-document/</para></summary>
	public partial class DeleteDescriptor<TDocument> : RequestDescriptorBase<DeleteDescriptor<TDocument>, DeleteRequestParameters, IDeleteRequest<TDocument>>, IDeleteRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceDelete;
		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public DeleteDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public DeleteDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public DeleteDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName IDeleteRequest.Index => Self.RouteValues.Get<IndexName>("index");
		Id IDeleteRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public DeleteDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public DeleteDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>only perform the delete operation if the last operation that has changed the document has the specified primary term</summary>
		public DeleteDescriptor<TDocument> IfPrimaryTerm(long? ifprimaryterm) => Qs("if_primary_term", ifprimaryterm);
		///<summary>only perform the delete operation if the last operation that has changed the document has the specified sequence number</summary>
		public DeleteDescriptor<TDocument> IfSequenceNumber(long? ifsequencenumber) => Qs("if_seq_no", ifsequencenumber);
		///<summary>If `true` then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this operation visible to search, if `false` (the default) then do nothing with refreshes.</summary>
		public DeleteDescriptor<TDocument> Refresh(Refresh? refresh) => Qs("refresh", refresh);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OpenSearch.Client will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public DeleteDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Explicit operation timeout</summary>
		public DeleteDescriptor<TDocument> Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Explicit version number for concurrency control</summary>
		public DeleteDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public DeleteDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
		///<summary>Sets the number of shard copies that must be active before proceeding with the delete operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public DeleteDescriptor<TDocument> WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
	}

	///<summary>Descriptor for DeleteByQuery <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/delete-by-query/</para></summary>
	public partial class DeleteByQueryDescriptor<TDocument> : RequestDescriptorBase<DeleteByQueryDescriptor<TDocument>, DeleteByQueryRequestParameters, IDeleteByQueryRequest<TDocument>>, IDeleteByQueryRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceDeleteByQuery;
		///<summary>/{index}/_delete_by_query</summary>
		///<param name = "index">this parameter is required</param>
		public DeleteByQueryDescriptor(Indices index): base(r => r.Required("index", index))
		{
		}

		///<summary>/{index}/_delete_by_query</summary>
		public DeleteByQueryDescriptor(): this(typeof(TDocument))
		{
		}

		// values part of the url path
		Indices IDeleteByQueryRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names to search; use the special string `_all` or Indices.All to perform the operation on all indices</summary>
		public DeleteByQueryDescriptor<TDocument> Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public DeleteByQueryDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public DeleteByQueryDescriptor<TDocument> AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have been specified)</summary>
		public DeleteByQueryDescriptor<TDocument> AllowNoIndices(bool? allownoindices = true) => Qs("allow_no_indices", allownoindices);
		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public DeleteByQueryDescriptor<TDocument> AnalyzeWildcard(bool? analyzewildcard = true) => Qs("analyze_wildcard", analyzewildcard);
		///<summary>The analyzer to use for the query string</summary>
		public DeleteByQueryDescriptor<TDocument> Analyzer(string analyzer) => Qs("analyzer", analyzer);
		///<summary>What to do when the delete by query hits version conflicts?</summary>
		public DeleteByQueryDescriptor<TDocument> Conflicts(Conflicts? conflicts) => Qs("conflicts", conflicts);
		///<summary>The default operator for query string query (AND or OR)</summary>
		public DeleteByQueryDescriptor<TDocument> DefaultOperator(DefaultOperator? defaultoperator) => Qs("default_operator", defaultoperator);
		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public DeleteByQueryDescriptor<TDocument> Df(string df) => Qs("df", df);
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public DeleteByQueryDescriptor<TDocument> ExpandWildcards(ExpandWildcards? expandwildcards) => Qs("expand_wildcards", expandwildcards);
		///<summary>Starting offset (default: 0)</summary>
		public DeleteByQueryDescriptor<TDocument> From(long? from) => Qs("from", from);
		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public DeleteByQueryDescriptor<TDocument> IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public DeleteByQueryDescriptor<TDocument> Lenient(bool? lenient = true) => Qs("lenient", lenient);
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public DeleteByQueryDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Query in the Lucene query string syntax</summary>
		public DeleteByQueryDescriptor<TDocument> QueryOnQueryString(string queryonquerystring) => Qs("q", queryonquerystring);
		///<summary>Should the effected indexes be refreshed?</summary>
		public DeleteByQueryDescriptor<TDocument> Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>Specify if request cache should be used for this request or not, defaults to index level setting</summary>
		public DeleteByQueryDescriptor<TDocument> RequestCache(bool? requestcache = true) => Qs("request_cache", requestcache);
		///<summary>The throttle for this request in sub-requests per second. -1 means no throttle.</summary>
		public DeleteByQueryDescriptor<TDocument> RequestsPerSecond(long? requestspersecond) => Qs("requests_per_second", requestspersecond);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OpenSearch.Client will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public DeleteByQueryDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public DeleteByQueryDescriptor<TDocument> Scroll(Time scroll) => Qs("scroll", scroll);
		///<summary>Size on the scroll request powering the delete by query</summary>
		public DeleteByQueryDescriptor<TDocument> ScrollSize(long? scrollsize) => Qs("scroll_size", scrollsize);
		///<summary>Explicit timeout for each search request. Defaults to no timeout.</summary>
		public DeleteByQueryDescriptor<TDocument> SearchTimeout(Time searchtimeout) => Qs("search_timeout", searchtimeout);
		///<summary>Search operation type</summary>
		public DeleteByQueryDescriptor<TDocument> SearchType(SearchType? searchtype) => Qs("search_type", searchtype);
		///<summary>The number of slices this task should be divided into. Defaults to 1, meaning the task isn't sliced into subtasks.</summary>
		public DeleteByQueryDescriptor<TDocument> Slices(long? slices) => Qs("slices", slices);
		///<summary>A comma-separated list of &lt;field&gt;:&lt;direction&gt; pairs</summary>
		public DeleteByQueryDescriptor<TDocument> Sort(params string[] sort) => Qs("sort", sort);
		///<summary>Whether the _source should be included in the response.</summary>
		public DeleteByQueryDescriptor<TDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public DeleteByQueryDescriptor<TDocument> SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public DeleteByQueryDescriptor<TDocument> SourceExcludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public DeleteByQueryDescriptor<TDocument> SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public DeleteByQueryDescriptor<TDocument> SourceIncludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_includes", fields?.Select(e => (Field)e));
		///<summary>Specific 'tag' of the request for logging and statistical purposes</summary>
		public DeleteByQueryDescriptor<TDocument> Stats(params string[] stats) => Qs("stats", stats);
		///<summary>The maximum number of documents to collect for each shard, upon reaching which the query execution will terminate early.</summary>
		public DeleteByQueryDescriptor<TDocument> TerminateAfter(long? terminateafter) => Qs("terminate_after", terminateafter);
		///<summary>Time each individual bulk request should wait for shards that are unavailable.</summary>
		public DeleteByQueryDescriptor<TDocument> Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Specify whether to return document version as part of a hit</summary>
		public DeleteByQueryDescriptor<TDocument> Version(bool? version = true) => Qs("version", version);
		///<summary>Sets the number of shard copies that must be active before proceeding with the delete by query operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public DeleteByQueryDescriptor<TDocument> WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
		///<summary>Should the request should block until the delete by query is complete.</summary>
		public DeleteByQueryDescriptor<TDocument> WaitForCompletion(bool? waitforcompletion = true) => Qs("wait_for_completion", waitforcompletion);
	}

	///<summary>Descriptor for DeleteByQueryRethrottle <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/delete-by-query/</para></summary>
	public partial class DeleteByQueryRethrottleDescriptor : RequestDescriptorBase<DeleteByQueryRethrottleDescriptor, DeleteByQueryRethrottleRequestParameters, IDeleteByQueryRethrottleRequest>, IDeleteByQueryRethrottleRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceDeleteByQueryRethrottle;
		///<summary>/_delete_by_query/{task_id}/_rethrottle</summary>
		///<param name = "taskId">this parameter is required</param>
		public DeleteByQueryRethrottleDescriptor(TaskId taskId): base(r => r.Required("task_id", taskId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteByQueryRethrottleDescriptor(): base()
		{
		}

		// values part of the url path
		TaskId IDeleteByQueryRethrottleRequest.TaskId => Self.RouteValues.Get<TaskId>("task_id");
		// Request parameters
		///<summary>The throttle to set on this request in floating sub-requests per second. -1 means set no throttle.</summary>
		public DeleteByQueryRethrottleDescriptor RequestsPerSecond(long? requestspersecond) => Qs("requests_per_second", requestspersecond);
	}

	///<summary>Descriptor for DeleteScript <para></para></summary>
	public partial class DeleteScriptDescriptor : RequestDescriptorBase<DeleteScriptDescriptor, DeleteScriptRequestParameters, IDeleteScriptRequest>, IDeleteScriptRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceDeleteScript;
		///<summary>/_scripts/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public DeleteScriptDescriptor(Id id): base(r => r.Required("id", id))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteScriptDescriptor(): base()
		{
		}

		// values part of the url path
		Id IDeleteScriptRequest.Id => Self.RouteValues.Get<Id>("id");
		// Request parameters
		///<summary>Specify timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public DeleteScriptDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Specify timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public DeleteScriptDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Explicit operation timeout</summary>
		public DeleteScriptDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
	}

	///<summary>Descriptor for DocumentExists <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/get-documents/</para></summary>
	public partial class DocumentExistsDescriptor<TDocument> : RequestDescriptorBase<DocumentExistsDescriptor<TDocument>, DocumentExistsRequestParameters, IDocumentExistsRequest<TDocument>>, IDocumentExistsRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceDocumentExists;
		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public DocumentExistsDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public DocumentExistsDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public DocumentExistsDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DocumentExistsDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName IDocumentExistsRequest.Index => Self.RouteValues.Get<IndexName>("index");
		Id IDocumentExistsRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public DocumentExistsDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public DocumentExistsDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public DocumentExistsDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public DocumentExistsDescriptor<TDocument> Realtime(bool? realtime = true) => Qs("realtime", realtime);
		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public DocumentExistsDescriptor<TDocument> Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OpenSearch.Client will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public DocumentExistsDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public DocumentExistsDescriptor<TDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public DocumentExistsDescriptor<TDocument> SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public DocumentExistsDescriptor<TDocument> SourceExcludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public DocumentExistsDescriptor<TDocument> SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public DocumentExistsDescriptor<TDocument> SourceIncludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_includes", fields?.Select(e => (Field)e));
		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public DocumentExistsDescriptor<TDocument> StoredFields(Fields storedfields) => Qs("stored_fields", storedfields);
		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public DocumentExistsDescriptor<TDocument> StoredFields(params Expression<Func<TDocument, object>>[] fields) => Qs("stored_fields", fields?.Select(e => (Field)e));
		///<summary>Explicit version number for concurrency control</summary>
		public DocumentExistsDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public DocumentExistsDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
	}

	///<summary>Descriptor for SourceExists <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/get-documents/</para></summary>
	public partial class SourceExistsDescriptor<TDocument> : RequestDescriptorBase<SourceExistsDescriptor<TDocument>, SourceExistsRequestParameters, ISourceExistsRequest<TDocument>>, ISourceExistsRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceSourceExists;
		///<summary>/{index}/_source/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public SourceExistsDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_source/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public SourceExistsDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_source/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public SourceExistsDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected SourceExistsDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName ISourceExistsRequest.Index => Self.RouteValues.Get<IndexName>("index");
		Id ISourceExistsRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public SourceExistsDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public SourceExistsDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public SourceExistsDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public SourceExistsDescriptor<TDocument> Realtime(bool? realtime = true) => Qs("realtime", realtime);
		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public SourceExistsDescriptor<TDocument> Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public SourceExistsDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public SourceExistsDescriptor<TDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public SourceExistsDescriptor<TDocument> SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public SourceExistsDescriptor<TDocument> SourceExcludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public SourceExistsDescriptor<TDocument> SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public SourceExistsDescriptor<TDocument> SourceIncludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_includes", fields?.Select(e => (Field)e));
		///<summary>Explicit version number for concurrency control</summary>
		public SourceExistsDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public SourceExistsDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
	}

	///<summary>Descriptor for Explain <para>https://opensearch.org/docs/latest/opensearch/rest-api/explain/</para></summary>
	public partial class ExplainDescriptor<TDocument> : RequestDescriptorBase<ExplainDescriptor<TDocument>, ExplainRequestParameters, IExplainRequest<TDocument>>, IExplainRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceExplain;
		///<summary>/{index}/_explain/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public ExplainDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_explain/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public ExplainDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_explain/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public ExplainDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ExplainDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName IExplainRequest.Index => Self.RouteValues.Get<IndexName>("index");
		Id IExplainRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public ExplainDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public ExplainDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>Specify whether wildcards and prefix queries in the query string query should be analyzed (default: false)</summary>
		public ExplainDescriptor<TDocument> AnalyzeWildcard(bool? analyzewildcard = true) => Qs("analyze_wildcard", analyzewildcard);
		///<summary>The analyzer for the query string query</summary>
		public ExplainDescriptor<TDocument> Analyzer(string analyzer) => Qs("analyzer", analyzer);
		///<summary>The default operator for query string query (AND or OR)</summary>
		public ExplainDescriptor<TDocument> DefaultOperator(DefaultOperator? defaultoperator) => Qs("default_operator", defaultoperator);
		///<summary>The default field for query string query (default: _all)</summary>
		public ExplainDescriptor<TDocument> Df(string df) => Qs("df", df);
		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public ExplainDescriptor<TDocument> Lenient(bool? lenient = true) => Qs("lenient", lenient);
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public ExplainDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Query in the Lucene query string syntax</summary>
		public ExplainDescriptor<TDocument> QueryOnQueryString(string queryonquerystring) => Qs("q", queryonquerystring);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public ExplainDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public ExplainDescriptor<TDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public ExplainDescriptor<TDocument> SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public ExplainDescriptor<TDocument> SourceExcludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public ExplainDescriptor<TDocument> SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public ExplainDescriptor<TDocument> SourceIncludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_includes", fields?.Select(e => (Field)e));
	}

	///<summary>Descriptor for FieldCapabilities <para></para></summary>
	public partial class FieldCapabilitiesDescriptor : RequestDescriptorBase<FieldCapabilitiesDescriptor, FieldCapabilitiesRequestParameters, IFieldCapabilitiesRequest>, IFieldCapabilitiesRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceFieldCapabilities;
		///<summary>/_field_caps</summary>
		public FieldCapabilitiesDescriptor(): base()
		{
		}

		///<summary>/{index}/_field_caps</summary>
		///<param name = "index">Optional, accepts null</param>
		public FieldCapabilitiesDescriptor(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		Indices IFieldCapabilitiesRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</summary>
		public FieldCapabilitiesDescriptor Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public FieldCapabilitiesDescriptor Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public FieldCapabilitiesDescriptor AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have been specified)</summary>
		public FieldCapabilitiesDescriptor AllowNoIndices(bool? allownoindices = true) => Qs("allow_no_indices", allownoindices);
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public FieldCapabilitiesDescriptor ExpandWildcards(ExpandWildcards? expandwildcards) => Qs("expand_wildcards", expandwildcards);
		///<summary>A comma-separated list of field names</summary>
		public FieldCapabilitiesDescriptor Fields(Fields fields) => Qs("fields", fields);
		///<summary>A comma-separated list of field names</summary>
		public FieldCapabilitiesDescriptor Fields<T>(params Expression<Func<T, object>>[] fields)
			where T : class => Qs("fields", fields?.Select(e => (Field)e));
		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public FieldCapabilitiesDescriptor IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Indicates whether unmapped fields should be included in the response.</summary>
		public FieldCapabilitiesDescriptor IncludeUnmapped(bool? includeunmapped = true) => Qs("include_unmapped", includeunmapped);
	}

	///<summary>Descriptor for Get <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/get-documents/</para></summary>
	public partial class GetDescriptor<TDocument> : RequestDescriptorBase<GetDescriptor<TDocument>, GetRequestParameters, IGetRequest<TDocument>>, IGetRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceGet;
		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public GetDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public GetDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public GetDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected GetDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName IGetRequest.Index => Self.RouteValues.Get<IndexName>("index");
		Id IGetRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public GetDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public GetDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public GetDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public GetDescriptor<TDocument> Realtime(bool? realtime = true) => Qs("realtime", realtime);
		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public GetDescriptor<TDocument> Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public GetDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public GetDescriptor<TDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public GetDescriptor<TDocument> SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public GetDescriptor<TDocument> SourceExcludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public GetDescriptor<TDocument> SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public GetDescriptor<TDocument> SourceIncludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_includes", fields?.Select(e => (Field)e));
		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public GetDescriptor<TDocument> StoredFields(Fields storedfields) => Qs("stored_fields", storedfields);
		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public GetDescriptor<TDocument> StoredFields(params Expression<Func<TDocument, object>>[] fields) => Qs("stored_fields", fields?.Select(e => (Field)e));
		///<summary>Explicit version number for concurrency control</summary>
		public GetDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public GetDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
	}

	///<summary>Descriptor for GetScript <para></para></summary>
	public partial class GetScriptDescriptor : RequestDescriptorBase<GetScriptDescriptor, GetScriptRequestParameters, IGetScriptRequest>, IGetScriptRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceGetScript;
		///<summary>/_scripts/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public GetScriptDescriptor(Id id): base(r => r.Required("id", id))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected GetScriptDescriptor(): base()
		{
		}

		// values part of the url path
		Id IGetScriptRequest.Id => Self.RouteValues.Get<Id>("id");
		// Request parameters
		///<summary>Specify timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public GetScriptDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Specify timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public GetScriptDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
	}

	///<summary>Descriptor for Source <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/get-documents/</para></summary>
	public partial class SourceDescriptor<TDocument> : RequestDescriptorBase<SourceDescriptor<TDocument>, SourceRequestParameters, ISourceRequest<TDocument>>, ISourceRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceSource;
		///<summary>/{index}/_source/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public SourceDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_source/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public SourceDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_source/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public SourceDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected SourceDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName ISourceRequest.Index => Self.RouteValues.Get<IndexName>("index");
		Id ISourceRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public SourceDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public SourceDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public SourceDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public SourceDescriptor<TDocument> Realtime(bool? realtime = true) => Qs("realtime", realtime);
		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public SourceDescriptor<TDocument> Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public SourceDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public SourceDescriptor<TDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public SourceDescriptor<TDocument> SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public SourceDescriptor<TDocument> SourceExcludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public SourceDescriptor<TDocument> SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public SourceDescriptor<TDocument> SourceIncludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_includes", fields?.Select(e => (Field)e));
		///<summary>Explicit version number for concurrency control</summary>
		public SourceDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public SourceDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
	}

	///<summary>Descriptor for Index <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/index-document/</para></summary>
	public partial class IndexDescriptor<TDocument> : RequestDescriptorBase<IndexDescriptor<TDocument>, IndexRequestParameters, IIndexRequest<TDocument>>, IIndexRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceIndex;
		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">Optional, accepts null</param>
		public IndexDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Optional("id", id))
		{
		}

		///<summary>/{index}/_doc</summary>
		///<param name = "index">this parameter is required</param>
		public IndexDescriptor(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">Optional, accepts null</param>
		public IndexDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_doc</summary>
		public IndexDescriptor(): this(typeof(TDocument))
		{
		}

		///<summary>/{index}/_doc/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public IndexDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Client.Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		// values part of the url path
		IndexName IIndexRequest<TDocument>.Index => Self.RouteValues.Get<IndexName>("index");
		Id IIndexRequest<TDocument>.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public IndexDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public IndexDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		///<summary>Document ID</summary>
		public IndexDescriptor<TDocument> Id(Id id) => Assign(id, (a, v) => a.RouteValues.Optional("id", v));
		// Request parameters
		///<summary>only perform the index operation if the last operation that has changed the document has the specified primary term</summary>
		public IndexDescriptor<TDocument> IfPrimaryTerm(long? ifprimaryterm) => Qs("if_primary_term", ifprimaryterm);
		///<summary>only perform the index operation if the last operation that has changed the document has the specified sequence number</summary>
		public IndexDescriptor<TDocument> IfSequenceNumber(long? ifsequencenumber) => Qs("if_seq_no", ifsequencenumber);
		///<summary>Explicit operation type. Defaults to `index` for requests with an explicit document ID, and to `create`for requests without an explicit document ID</summary>
		public IndexDescriptor<TDocument> OpType(OpType? optype) => Qs("op_type", optype);
		///<summary>The pipeline id to preprocess incoming documents with</summary>
		public IndexDescriptor<TDocument> Pipeline(string pipeline) => Qs("pipeline", pipeline);
		///<summary>If `true` then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this operation visible to search, if `false` (the default) then do nothing with refreshes.</summary>
		public IndexDescriptor<TDocument> Refresh(Refresh? refresh) => Qs("refresh", refresh);
		///<summary>When true, requires destination to be an alias. Default is false</summary>
		public IndexDescriptor<TDocument> RequireAlias(bool? requirealias = true) => Qs("require_alias", requirealias);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public IndexDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Explicit operation timeout</summary>
		public IndexDescriptor<TDocument> Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Explicit version number for concurrency control</summary>
		public IndexDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public IndexDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
		///<summary>Sets the number of shard copies that must be active before proceeding with the index operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public IndexDescriptor<TDocument> WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
	}

	///<summary>Descriptor for RootNodeInfo <para>https://opensearch.org/docs/latest/opensearch/index/</para></summary>
	public partial class RootNodeInfoDescriptor : RequestDescriptorBase<RootNodeInfoDescriptor, RootNodeInfoRequestParameters, IRootNodeInfoRequest>, IRootNodeInfoRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceRootNodeInfo;
	// values part of the url path
	// Request parameters
	}

	///<summary>Descriptor for MultiGet <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/multi-get/</para></summary>
	public partial class MultiGetDescriptor : RequestDescriptorBase<MultiGetDescriptor, MultiGetRequestParameters, IMultiGetRequest>, IMultiGetRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceMultiGet;
		///<summary>/_mget</summary>
		public MultiGetDescriptor(): base()
		{
		}

		///<summary>/{index}/_mget</summary>
		///<param name = "index">Optional, accepts null</param>
		public MultiGetDescriptor(IndexName index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		IndexName IMultiGetRequest.Index => Self.RouteValues.Get<IndexName>("index");
		///<summary>The name of the index</summary>
		public MultiGetDescriptor Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public MultiGetDescriptor Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (IndexName)v));
		// Request parameters
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public MultiGetDescriptor Preference(string preference) => Qs("preference", preference);
		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public MultiGetDescriptor Realtime(bool? realtime = true) => Qs("realtime", realtime);
		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public MultiGetDescriptor Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public MultiGetDescriptor Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public MultiGetDescriptor SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public MultiGetDescriptor SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public MultiGetDescriptor SourceExcludes<T>(params Expression<Func<T, object>>[] fields)
			where T : class => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public MultiGetDescriptor SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public MultiGetDescriptor SourceIncludes<T>(params Expression<Func<T, object>>[] fields)
			where T : class => Qs("_source_includes", fields?.Select(e => (Field)e));
	}

	///<summary>Descriptor for MultiSearch <para>https://opensearch.org/docs/latest/opensearch/rest-api/multi-search/</para></summary>
	public partial class MultiSearchDescriptor : RequestDescriptorBase<MultiSearchDescriptor, MultiSearchRequestParameters, IMultiSearchRequest>, IMultiSearchRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceMultiSearch;
		///<summary>/_msearch</summary>
		public MultiSearchDescriptor(): base()
		{
		}

		///<summary>/{index}/_msearch</summary>
		///<param name = "index">Optional, accepts null</param>
		public MultiSearchDescriptor(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		Indices IMultiSearchRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names to use as default</summary>
		public MultiSearchDescriptor Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public MultiSearchDescriptor Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public MultiSearchDescriptor AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public MultiSearchDescriptor CcsMinimizeRoundtrips(bool? ccsminimizeroundtrips = true) => Qs("ccs_minimize_roundtrips", ccsminimizeroundtrips);
		///<summary>Controls the maximum number of concurrent searches the multi search api will execute</summary>
		public MultiSearchDescriptor MaxConcurrentSearches(long? maxconcurrentsearches) => Qs("max_concurrent_searches", maxconcurrentsearches);
		///<summary>The number of concurrent shard requests each sub search executes concurrently per node. This value should be used to limit the impact of the search on the cluster in order to limit the number of concurrent shard requests</summary>
		public MultiSearchDescriptor MaxConcurrentShardRequests(long? maxconcurrentshardrequests) => Qs("max_concurrent_shard_requests", maxconcurrentshardrequests);
		///<summary>A threshold that enforces a pre-filter roundtrip to prefilter search shards based on query rewriting if the number of shards the search request expands to exceeds the threshold. This filter roundtrip can limit the number of shards significantly if for instance a shard can not match any documents based on its rewrite method ie. if date filters are mandatory to match but the shard bounds and the query are disjoint.</summary>
		public MultiSearchDescriptor PreFilterShardSize(long? prefiltershardsize) => Qs("pre_filter_shard_size", prefiltershardsize);
		///<summary>Search operation type</summary>
		public MultiSearchDescriptor SearchType(SearchType? searchtype) => Qs("search_type", searchtype);
		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public MultiSearchDescriptor TotalHitsAsInteger(bool? totalhitsasinteger = true) => Qs("rest_total_hits_as_int", totalhitsasinteger);
		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public MultiSearchDescriptor TypedKeys(bool? typedkeys = true) => Qs("typed_keys", typedkeys);
	}

	///<summary>Descriptor for MultiSearchTemplate <para>https://opensearch.org/docs/latest/opensearch/rest-api/multi-search/</para></summary>
	public partial class MultiSearchTemplateDescriptor : RequestDescriptorBase<MultiSearchTemplateDescriptor, MultiSearchTemplateRequestParameters, IMultiSearchTemplateRequest>, IMultiSearchTemplateRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceMultiSearchTemplate;
		///<summary>/_msearch/template</summary>
		public MultiSearchTemplateDescriptor(): base()
		{
		}

		///<summary>/{index}/_msearch/template</summary>
		///<param name = "index">Optional, accepts null</param>
		public MultiSearchTemplateDescriptor(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		Indices IMultiSearchTemplateRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names to use as default</summary>
		public MultiSearchTemplateDescriptor Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public MultiSearchTemplateDescriptor Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public MultiSearchTemplateDescriptor AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public MultiSearchTemplateDescriptor CcsMinimizeRoundtrips(bool? ccsminimizeroundtrips = true) => Qs("ccs_minimize_roundtrips", ccsminimizeroundtrips);
		///<summary>Controls the maximum number of concurrent searches the multi search api will execute</summary>
		public MultiSearchTemplateDescriptor MaxConcurrentSearches(long? maxconcurrentsearches) => Qs("max_concurrent_searches", maxconcurrentsearches);
		///<summary>Search operation type</summary>
		public MultiSearchTemplateDescriptor SearchType(SearchType? searchtype) => Qs("search_type", searchtype);
		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public MultiSearchTemplateDescriptor TotalHitsAsInteger(bool? totalhitsasinteger = true) => Qs("rest_total_hits_as_int", totalhitsasinteger);
		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public MultiSearchTemplateDescriptor TypedKeys(bool? typedkeys = true) => Qs("typed_keys", typedkeys);
	}

	///<summary>Descriptor for MultiTermVectors <para></para></summary>
	public partial class MultiTermVectorsDescriptor : RequestDescriptorBase<MultiTermVectorsDescriptor, MultiTermVectorsRequestParameters, IMultiTermVectorsRequest>, IMultiTermVectorsRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceMultiTermVectors;
		///<summary>/_mtermvectors</summary>
		public MultiTermVectorsDescriptor(): base()
		{
		}

		///<summary>/{index}/_mtermvectors</summary>
		///<param name = "index">Optional, accepts null</param>
		public MultiTermVectorsDescriptor(IndexName index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		IndexName IMultiTermVectorsRequest.Index => Self.RouteValues.Get<IndexName>("index");
		///<summary>The index in which the document resides.</summary>
		public MultiTermVectorsDescriptor Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public MultiTermVectorsDescriptor Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (IndexName)v));
		// Request parameters
		///<summary>Specifies if document count, sum of document frequencies and sum of total term frequencies should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public MultiTermVectorsDescriptor FieldStatistics(bool? fieldstatistics = true) => Qs("field_statistics", fieldstatistics);
		///<summary>A comma-separated list of fields to return. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public MultiTermVectorsDescriptor Fields(Fields fields) => Qs("fields", fields);
		///<summary>A comma-separated list of fields to return. Applies to all returned documents unless otherwise specified in body &quot;params&quot; or &quot;docs&quot;.</summary>
		public MultiTermVectorsDescriptor Fields<T>(params Expression<Func<T, object>>[] fields)
			where T : class => Qs("fields", fields?.Select(e => (Field)e));
		///<summary>Specifies if term offsets should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public MultiTermVectorsDescriptor Offsets(bool? offsets = true) => Qs("offsets", offsets);
		///<summary>Specifies if term payloads should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public MultiTermVectorsDescriptor Payloads(bool? payloads = true) => Qs("payloads", payloads);
		///<summary>Specifies if term positions should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public MultiTermVectorsDescriptor Positions(bool? positions = true) => Qs("positions", positions);
		///<summary>Specify the node or shard the operation should be performed on (default: random) .Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public MultiTermVectorsDescriptor Preference(string preference) => Qs("preference", preference);
		///<summary>Specifies if requests are real-time as opposed to near-real-time (default: true).</summary>
		public MultiTermVectorsDescriptor Realtime(bool? realtime = true) => Qs("realtime", realtime);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public MultiTermVectorsDescriptor Routing(Routing routing) => Qs("routing", routing);
		///<summary>Specifies if total term frequency and document frequency should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public MultiTermVectorsDescriptor TermStatistics(bool? termstatistics = true) => Qs("term_statistics", termstatistics);
		///<summary>Explicit version number for concurrency control</summary>
		public MultiTermVectorsDescriptor Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public MultiTermVectorsDescriptor VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
	}

	///<summary>Descriptor for Ping <para>https://opensearch.org/docs/latest/opensearch/index/</para></summary>
	public partial class PingDescriptor : RequestDescriptorBase<PingDescriptor, PingRequestParameters, IPingRequest>, IPingRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespacePing;
	// values part of the url path
	// Request parameters
	}

	///<summary>Descriptor for PutScript <para></para></summary>
	public partial class PutScriptDescriptor : RequestDescriptorBase<PutScriptDescriptor, PutScriptRequestParameters, IPutScriptRequest>, IPutScriptRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespacePutScript;
		///<summary>/_scripts/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public PutScriptDescriptor(Id id): base(r => r.Required("id", id))
		{
		}

		///<summary>/_scripts/{id}/{context}</summary>
		///<param name = "id">this parameter is required</param>
		///<param name = "context">Optional, accepts null</param>
		public PutScriptDescriptor(Id id, Name context): base(r => r.Required("id", id).Optional("context", context))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PutScriptDescriptor(): base()
		{
		}

		// values part of the url path
		Id IPutScriptRequest.Id => Self.RouteValues.Get<Id>("id");
		Name IPutScriptRequest.Context => Self.RouteValues.Get<Name>("context");
		///<summary>Script context</summary>
		public PutScriptDescriptor Context(Name context) => Assign(context, (a, v) => a.RouteValues.Optional("context", v));
		// Request parameters
		///<summary>Specify timeout for connection to master node</summary>
		///<remarks>Deprecated as of OpenSearch 2.0, use <see cref="ClusterManagerTimeout"/> instead</remarks>
		public PutScriptDescriptor MasterTimeout(Time mastertimeout) => Qs("master_timeout", mastertimeout);
		///<summary>Specify timeout for connection to cluster_manager node</summary>
		///<remarks>Introduced in OpenSearch 2.0 instead of <see cref="MasterTimeout"/></remarks>
		public PutScriptDescriptor ClusterManagerTimeout(Time timeout) => Qs("cluster_manager_timeout", timeout);
		///<summary>Explicit operation timeout</summary>
		public PutScriptDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
	}

	///<summary>Descriptor for ReindexOnServer <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/reindex/</para></summary>
	public partial class ReindexOnServerDescriptor : RequestDescriptorBase<ReindexOnServerDescriptor, ReindexOnServerRequestParameters, IReindexOnServerRequest>, IReindexOnServerRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceReindexOnServer;
		// values part of the url path
		// Request parameters
		///<summary>Should the affected indexes be refreshed?</summary>
		public ReindexOnServerDescriptor Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>The throttle to set on this request in sub-requests per second. -1 means no throttle.</summary>
		public ReindexOnServerDescriptor RequestsPerSecond(long? requestspersecond) => Qs("requests_per_second", requestspersecond);
		///<summary>Control how long to keep the search context alive</summary>
		public ReindexOnServerDescriptor Scroll(Time scroll) => Qs("scroll", scroll);
		///<summary>The number of slices this task should be divided into. Defaults to 1, meaning the task isn't sliced into subtasks. Can be set to `auto`.</summary>
		public ReindexOnServerDescriptor Slices(long? slices) => Qs("slices", slices);
		///<summary>Time each individual bulk request should wait for shards that are unavailable.</summary>
		public ReindexOnServerDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Sets the number of shard copies that must be active before proceeding with the reindex operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public ReindexOnServerDescriptor WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
		///<summary>Should the request should block until the reindex is complete.</summary>
		public ReindexOnServerDescriptor WaitForCompletion(bool? waitforcompletion = true) => Qs("wait_for_completion", waitforcompletion);
	}

	///<summary>Descriptor for ReindexRethrottle <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/reindex/</para></summary>
	public partial class ReindexRethrottleDescriptor : RequestDescriptorBase<ReindexRethrottleDescriptor, ReindexRethrottleRequestParameters, IReindexRethrottleRequest>, IReindexRethrottleRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceReindexRethrottle;
		///<summary>/_reindex/{task_id}/_rethrottle</summary>
		///<param name = "taskId">this parameter is required</param>
		public ReindexRethrottleDescriptor(TaskId taskId): base(r => r.Required("task_id", taskId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ReindexRethrottleDescriptor(): base()
		{
		}

		// values part of the url path
		TaskId IReindexRethrottleRequest.TaskId => Self.RouteValues.Get<TaskId>("task_id");
		// Request parameters
		///<summary>The throttle to set on this request in floating sub-requests per second. -1 means set no throttle.</summary>
		public ReindexRethrottleDescriptor RequestsPerSecond(long? requestspersecond) => Qs("requests_per_second", requestspersecond);
	}

	///<summary>Descriptor for RenderSearchTemplate <para>https://opensearch.org/docs/latest/opensearch/search-template/</para></summary>
	public partial class RenderSearchTemplateDescriptor : RequestDescriptorBase<RenderSearchTemplateDescriptor, RenderSearchTemplateRequestParameters, IRenderSearchTemplateRequest>, IRenderSearchTemplateRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceRenderSearchTemplate;
		///<summary>/_render/template</summary>
		public RenderSearchTemplateDescriptor(): base()
		{
		}

		///<summary>/_render/template/{id}</summary>
		///<param name = "id">Optional, accepts null</param>
		public RenderSearchTemplateDescriptor(Id id): base(r => r.Optional("id", id))
		{
		}

		// values part of the url path
		Id IRenderSearchTemplateRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The id of the stored search template</summary>
		public RenderSearchTemplateDescriptor Id(Id id) => Assign(id, (a, v) => a.RouteValues.Optional("id", v));
	// Request parameters
	}

	///<summary>Descriptor for ExecutePainlessScript <para></para></summary>
	public partial class ExecutePainlessScriptDescriptor : RequestDescriptorBase<ExecutePainlessScriptDescriptor, ExecutePainlessScriptRequestParameters, IExecutePainlessScriptRequest>, IExecutePainlessScriptRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceExecutePainlessScript;
	// values part of the url path
	// Request parameters
	}

	///<summary>Descriptor for Scroll <para>https://opensearch.org/docs/latest/opensearch/rest-api/search/#request-body</para></summary>
	public partial class ScrollDescriptor<TInferDocument> : RequestDescriptorBase<ScrollDescriptor<TInferDocument>, ScrollRequestParameters, IScrollRequest>, IScrollRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceScroll;
		// values part of the url path
		// Request parameters
		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public ScrollDescriptor<TInferDocument> TotalHitsAsInteger(bool? totalhitsasinteger = true) => Qs("rest_total_hits_as_int", totalhitsasinteger);
	}

	///<summary>Descriptor for Search <para>https://opensearch.org/docs/latest/opensearch/rest-api/search/</para></summary>
	public partial class SearchDescriptor<TInferDocument> : RequestDescriptorBase<SearchDescriptor<TInferDocument>, SearchRequestParameters, ISearchRequest<TInferDocument>>, ISearchRequest<TInferDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceSearch;
		///<summary>/{index}/_search</summary>
		public SearchDescriptor(): this(typeof(TInferDocument))
		{
		}

		///<summary>/{index}/_search</summary>
		///<param name = "index">Optional, accepts null</param>
		public SearchDescriptor(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		Indices ISearchRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names to search; use the special string `_all` or Indices.All to perform the operation on all indices</summary>
		public SearchDescriptor<TInferDocument> Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public SearchDescriptor<TInferDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public SearchDescriptor<TInferDocument> AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have been specified)</summary>
		public SearchDescriptor<TInferDocument> AllowNoIndices(bool? allownoindices = true) => Qs("allow_no_indices", allownoindices);
		///<summary>Indicate if an error should be returned if there is a partial search failure or timeout</summary>
		public SearchDescriptor<TInferDocument> AllowPartialSearchResults(bool? allowpartialsearchresults = true) => Qs("allow_partial_search_results", allowpartialsearchresults);
		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public SearchDescriptor<TInferDocument> AnalyzeWildcard(bool? analyzewildcard = true) => Qs("analyze_wildcard", analyzewildcard);
		///<summary>The analyzer to use for the query string</summary>
		public SearchDescriptor<TInferDocument> Analyzer(string analyzer) => Qs("analyzer", analyzer);
		///<summary>The number of shard results that should be reduced at once on the coordinating node. This value should be used as a protection mechanism to reduce the memory overhead per search request if the potential number of shards in the request can be large.</summary>
		public SearchDescriptor<TInferDocument> BatchedReduceSize(long? batchedreducesize) => Qs("batched_reduce_size", batchedreducesize);
		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public SearchDescriptor<TInferDocument> CcsMinimizeRoundtrips(bool? ccsminimizeroundtrips = true) => Qs("ccs_minimize_roundtrips", ccsminimizeroundtrips);
		///<summary>The default operator for query string query (AND or OR)</summary>
		public SearchDescriptor<TInferDocument> DefaultOperator(DefaultOperator? defaultoperator) => Qs("default_operator", defaultoperator);
		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public SearchDescriptor<TInferDocument> Df(string df) => Qs("df", df);
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public SearchDescriptor<TInferDocument> ExpandWildcards(ExpandWildcards? expandwildcards) => Qs("expand_wildcards", expandwildcards);
		///<summary>Whether specified concrete, expanded or aliased indices should be ignored when throttled</summary>
		public SearchDescriptor<TInferDocument> IgnoreThrottled(bool? ignorethrottled = true) => Qs("ignore_throttled", ignorethrottled);
		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public SearchDescriptor<TInferDocument> IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public SearchDescriptor<TInferDocument> Lenient(bool? lenient = true) => Qs("lenient", lenient);
		///<summary>The number of concurrent shard requests per node this search executes concurrently. This value should be used to limit the impact of the search on the cluster in order to limit the number of concurrent shard requests</summary>
		public SearchDescriptor<TInferDocument> MaxConcurrentShardRequests(long? maxconcurrentshardrequests) => Qs("max_concurrent_shard_requests", maxconcurrentshardrequests);
		///<summary>A threshold that enforces a pre-filter roundtrip to prefilter search shards based on query rewriting if the number of shards the search request expands to exceeds the threshold. This filter roundtrip can limit the number of shards significantly if for instance a shard can not match any documents based on its rewrite method ie. if date filters are mandatory to match but the shard bounds and the query are disjoint.</summary>
		public SearchDescriptor<TInferDocument> PreFilterShardSize(long? prefiltershardsize) => Qs("pre_filter_shard_size", prefiltershardsize);
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public SearchDescriptor<TInferDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Query in the Lucene query string syntax</summary>
		public SearchDescriptor<TInferDocument> QueryOnQueryString(string queryonquerystring) => Qs("q", queryonquerystring);
		///<summary>Specify if request cache should be used for this request or not, defaults to index level setting</summary>
		public SearchDescriptor<TInferDocument> RequestCache(bool? requestcache = true) => Qs("request_cache", requestcache);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public SearchDescriptor<TInferDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public SearchDescriptor<TInferDocument> Scroll(Time scroll) => Qs("scroll", scroll);
		///<summary>Search operation type</summary>
		public SearchDescriptor<TInferDocument> SearchType(SearchType? searchtype) => Qs("search_type", searchtype);
		///<summary>Specify whether to return sequence number and primary term of the last modification of each hit</summary>
		public SearchDescriptor<TInferDocument> SequenceNumberPrimaryTerm(bool? sequencenumberprimaryterm = true) => Qs("seq_no_primary_term", sequencenumberprimaryterm);
		///<summary>Specific 'tag' of the request for logging and statistical purposes</summary>
		public SearchDescriptor<TInferDocument> Stats(params string[] stats) => Qs("stats", stats);
		///<summary>Specify which field to use for suggestions</summary>
		public SearchDescriptor<TInferDocument> SuggestField(Field suggestfield) => Qs("suggest_field", suggestfield);
		///<summary>Specify which field to use for suggestions</summary>
		public SearchDescriptor<TInferDocument> SuggestField(Expression<Func<TInferDocument, object>> field) => Qs("suggest_field", (Field)field);
		///<summary>Specify suggest mode</summary>
		public SearchDescriptor<TInferDocument> SuggestMode(SuggestMode? suggestmode) => Qs("suggest_mode", suggestmode);
		///<summary>How many suggestions to return in response</summary>
		public SearchDescriptor<TInferDocument> SuggestSize(long? suggestsize) => Qs("suggest_size", suggestsize);
		///<summary>The source text for which the suggestions should be returned</summary>
		public SearchDescriptor<TInferDocument> SuggestText(string suggesttext) => Qs("suggest_text", suggesttext);
		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public SearchDescriptor<TInferDocument> TotalHitsAsInteger(bool? totalhitsasinteger = true) => Qs("rest_total_hits_as_int", totalhitsasinteger);
		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public SearchDescriptor<TInferDocument> TypedKeys(bool? typedkeys = true) => Qs("typed_keys", typedkeys);
	}

	///<summary>Descriptor for SearchShards <para>https://opensearch.org/docs/latest/security-plugin/access-control/cross-cluster-search/</para></summary>
	public partial class SearchShardsDescriptor<TDocument> : RequestDescriptorBase<SearchShardsDescriptor<TDocument>, SearchShardsRequestParameters, ISearchShardsRequest<TDocument>>, ISearchShardsRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceSearchShards;
		///<summary>/{index}/_search_shards</summary>
		public SearchShardsDescriptor(): this(typeof(TDocument))
		{
		}

		///<summary>/{index}/_search_shards</summary>
		///<param name = "index">Optional, accepts null</param>
		public SearchShardsDescriptor(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		Indices ISearchShardsRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names to search; use the special string `_all` or Indices.All to perform the operation on all indices</summary>
		public SearchShardsDescriptor<TDocument> Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public SearchShardsDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public SearchShardsDescriptor<TDocument> AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have been specified)</summary>
		public SearchShardsDescriptor<TDocument> AllowNoIndices(bool? allownoindices = true) => Qs("allow_no_indices", allownoindices);
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public SearchShardsDescriptor<TDocument> ExpandWildcards(ExpandWildcards? expandwildcards) => Qs("expand_wildcards", expandwildcards);
		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public SearchShardsDescriptor<TDocument> IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Return local information, do not retrieve the state from cluster_manager node (default: false)</summary>
		public SearchShardsDescriptor<TDocument> Local(bool? local = true) => Qs("local", local);
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public SearchShardsDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public SearchShardsDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
	}

	///<summary>Descriptor for SearchTemplate <para>https://opensearch.org/docs/latest/opensearch/search-template/</para></summary>
	public partial class SearchTemplateDescriptor<TDocument> : RequestDescriptorBase<SearchTemplateDescriptor<TDocument>, SearchTemplateRequestParameters, ISearchTemplateRequest>, ISearchTemplateRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceSearchTemplate;
		///<summary>/{index}/_search/template</summary>
		public SearchTemplateDescriptor(): this(typeof(TDocument))
		{
		}

		///<summary>/{index}/_search/template</summary>
		///<param name = "index">Optional, accepts null</param>
		public SearchTemplateDescriptor(Indices index): base(r => r.Optional("index", index))
		{
		}

		// values part of the url path
		Indices ISearchTemplateRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names to search; use the special string `_all` or Indices.All to perform the operation on all indices</summary>
		public SearchTemplateDescriptor<TDocument> Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Optional("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public SearchTemplateDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Optional("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public SearchTemplateDescriptor<TDocument> AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have been specified)</summary>
		public SearchTemplateDescriptor<TDocument> AllowNoIndices(bool? allownoindices = true) => Qs("allow_no_indices", allownoindices);
		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public SearchTemplateDescriptor<TDocument> CcsMinimizeRoundtrips(bool? ccsminimizeroundtrips = true) => Qs("ccs_minimize_roundtrips", ccsminimizeroundtrips);
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public SearchTemplateDescriptor<TDocument> ExpandWildcards(ExpandWildcards? expandwildcards) => Qs("expand_wildcards", expandwildcards);
		///<summary>Specify whether to return detailed information about score computation as part of a hit</summary>
		public SearchTemplateDescriptor<TDocument> Explain(bool? explain = true) => Qs("explain", explain);
		///<summary>Whether specified concrete, expanded or aliased indices should be ignored when throttled</summary>
		public SearchTemplateDescriptor<TDocument> IgnoreThrottled(bool? ignorethrottled = true) => Qs("ignore_throttled", ignorethrottled);
		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public SearchTemplateDescriptor<TDocument> IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public SearchTemplateDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Specify whether to profile the query execution</summary>
		public SearchTemplateDescriptor<TDocument> Profile(bool? profile = true) => Qs("profile", profile);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public SearchTemplateDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public SearchTemplateDescriptor<TDocument> Scroll(Time scroll) => Qs("scroll", scroll);
		///<summary>Search operation type</summary>
		public SearchTemplateDescriptor<TDocument> SearchType(SearchType? searchtype) => Qs("search_type", searchtype);
		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public SearchTemplateDescriptor<TDocument> TotalHitsAsInteger(bool? totalhitsasinteger = true) => Qs("rest_total_hits_as_int", totalhitsasinteger);
		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public SearchTemplateDescriptor<TDocument> TypedKeys(bool? typedkeys = true) => Qs("typed_keys", typedkeys);
	}

	///<summary>Descriptor for TermVectors <para></para></summary>
	public partial class TermVectorsDescriptor<TDocument> : RequestDescriptorBase<TermVectorsDescriptor<TDocument>, TermVectorsRequestParameters, ITermVectorsRequest<TDocument>>, ITermVectorsRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceTermVectors;
		///<summary>/{index}/_termvectors/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">Optional, accepts null</param>
		public TermVectorsDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Optional("id", id))
		{
		}

		///<summary>/{index}/_termvectors</summary>
		///<param name = "index">this parameter is required</param>
		public TermVectorsDescriptor(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>/{index}/_termvectors/{id}</summary>
		///<param name = "id">Optional, accepts null</param>
		public TermVectorsDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_termvectors</summary>
		public TermVectorsDescriptor(): this(typeof(TDocument))
		{
		}

		///<summary>/{index}/_termvectors/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public TermVectorsDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Client.Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		// values part of the url path
		IndexName ITermVectorsRequest<TDocument>.Index => Self.RouteValues.Get<IndexName>("index");
		Id ITermVectorsRequest<TDocument>.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The index in which the document resides.</summary>
		public TermVectorsDescriptor<TDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public TermVectorsDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		///<summary>The id of the document, when not specified a doc param should be supplied.</summary>
		public TermVectorsDescriptor<TDocument> Id(Id id) => Assign(id, (a, v) => a.RouteValues.Optional("id", v));
		// Request parameters
		///<summary>Specifies if document count, sum of document frequencies and sum of total term frequencies should be returned.</summary>
		public TermVectorsDescriptor<TDocument> FieldStatistics(bool? fieldstatistics = true) => Qs("field_statistics", fieldstatistics);
		///<summary>A comma-separated list of fields to return.</summary>
		public TermVectorsDescriptor<TDocument> Fields(Fields fields) => Qs("fields", fields);
		///<summary>A comma-separated list of fields to return.</summary>
		public TermVectorsDescriptor<TDocument> Fields(params Expression<Func<TDocument, object>>[] fields) => Qs("fields", fields?.Select(e => (Field)e));
		///<summary>Specifies if term offsets should be returned.</summary>
		public TermVectorsDescriptor<TDocument> Offsets(bool? offsets = true) => Qs("offsets", offsets);
		///<summary>Specifies if term payloads should be returned.</summary>
		public TermVectorsDescriptor<TDocument> Payloads(bool? payloads = true) => Qs("payloads", payloads);
		///<summary>Specifies if term positions should be returned.</summary>
		public TermVectorsDescriptor<TDocument> Positions(bool? positions = true) => Qs("positions", positions);
		///<summary>Specify the node or shard the operation should be performed on (default: random).</summary>
		public TermVectorsDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Specifies if request is real-time as opposed to near-real-time (default: true).</summary>
		public TermVectorsDescriptor<TDocument> Realtime(bool? realtime = true) => Qs("realtime", realtime);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public TermVectorsDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Specifies if total term frequency and document frequency should be returned.</summary>
		public TermVectorsDescriptor<TDocument> TermStatistics(bool? termstatistics = true) => Qs("term_statistics", termstatistics);
		///<summary>Explicit version number for concurrency control</summary>
		public TermVectorsDescriptor<TDocument> Version(long? version) => Qs("version", version);
		///<summary>Specific version type</summary>
		public TermVectorsDescriptor<TDocument> VersionType(VersionType? versiontype) => Qs("version_type", versiontype);
	}

	///<summary>Descriptor for Update <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/update-document/</para></summary>
	public partial class UpdateDescriptor<TDocument, TPartialDocument> : RequestDescriptorBase<UpdateDescriptor<TDocument, TPartialDocument>, UpdateRequestParameters, IUpdateRequest<TDocument, TPartialDocument>>, IUpdateRequest<TDocument, TPartialDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceUpdate;
		///<summary>/{index}/_update/{id}</summary>
		///<param name = "index">this parameter is required</param>
		///<param name = "id">this parameter is required</param>
		public UpdateDescriptor(IndexName index, Id id): base(r => r.Required("index", index).Required("id", id))
		{
		}

		///<summary>/{index}/_update/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public UpdateDescriptor(Id id): this(typeof(TDocument), id)
		{
		}

		///<summary>/{index}/_update/{id}</summary>
		///<param name = "id">The document used to resolve the path from</param>
		public UpdateDescriptor(TDocument documentWithId, IndexName index = null, Id id = null): this(index ?? typeof(TDocument), id ?? Id.From(documentWithId)) => DocumentFromPath(documentWithId);
		partial void DocumentFromPath(TDocument document);
		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected UpdateDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName IUpdateRequest<TDocument, TPartialDocument>.Index => Self.RouteValues.Get<IndexName>("index");
		Id IUpdateRequest<TDocument, TPartialDocument>.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The name of the index</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
		// Request parameters
		///<summary>only perform the update operation if the last operation that has changed the document has the specified primary term</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> IfPrimaryTerm(long? ifprimaryterm) => Qs("if_primary_term", ifprimaryterm);
		///<summary>only perform the update operation if the last operation that has changed the document has the specified sequence number</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> IfSequenceNumber(long? ifsequencenumber) => Qs("if_seq_no", ifsequencenumber);
		///<summary>The script language (default: painless)</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> Lang(string lang) => Qs("lang", lang);
		///<summary>If `true` then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this operation visible to search, if `false` (the default) then do nothing with refreshes.</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> Refresh(Refresh? refresh) => Qs("refresh", refresh);
		///<summary>When true, requires destination is an alias. Default is false</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> RequireAlias(bool? requirealias = true) => Qs("require_alias", requirealias);
		///<summary>Specify how many times should the operation be retried when a conflict occurs (default: 0)</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> RetryOnConflict(long? retryonconflict) => Qs("retry_on_conflict", retryonconflict);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Whether the _source should be included in the response.</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>Explicit operation timeout</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Sets the number of shard copies that must be active before proceeding with the update operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public UpdateDescriptor<TDocument, TPartialDocument> WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
	}

	///<summary>Descriptor for UpdateByQuery <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/update-by-query/</para></summary>
	public partial class UpdateByQueryDescriptor<TDocument> : RequestDescriptorBase<UpdateByQueryDescriptor<TDocument>, UpdateByQueryRequestParameters, IUpdateByQueryRequest<TDocument>>, IUpdateByQueryRequest<TDocument>
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceUpdateByQuery;
		///<summary>/{index}/_update_by_query</summary>
		///<param name = "index">this parameter is required</param>
		public UpdateByQueryDescriptor(Indices index): base(r => r.Required("index", index))
		{
		}

		///<summary>/{index}/_update_by_query</summary>
		public UpdateByQueryDescriptor(): this(typeof(TDocument))
		{
		}

		// values part of the url path
		Indices IUpdateByQueryRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>A comma-separated list of index names to search; use the special string `_all` or Indices.All to perform the operation on all indices</summary>
		public UpdateByQueryDescriptor<TDocument> Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public UpdateByQueryDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public UpdateByQueryDescriptor<TDocument> AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have been specified)</summary>
		public UpdateByQueryDescriptor<TDocument> AllowNoIndices(bool? allownoindices = true) => Qs("allow_no_indices", allownoindices);
		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public UpdateByQueryDescriptor<TDocument> AnalyzeWildcard(bool? analyzewildcard = true) => Qs("analyze_wildcard", analyzewildcard);
		///<summary>The analyzer to use for the query string</summary>
		public UpdateByQueryDescriptor<TDocument> Analyzer(string analyzer) => Qs("analyzer", analyzer);
		///<summary>What to do when the update by query hits version conflicts?</summary>
		public UpdateByQueryDescriptor<TDocument> Conflicts(Conflicts? conflicts) => Qs("conflicts", conflicts);
		///<summary>The default operator for query string query (AND or OR)</summary>
		public UpdateByQueryDescriptor<TDocument> DefaultOperator(DefaultOperator? defaultoperator) => Qs("default_operator", defaultoperator);
		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public UpdateByQueryDescriptor<TDocument> Df(string df) => Qs("df", df);
		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public UpdateByQueryDescriptor<TDocument> ExpandWildcards(ExpandWildcards? expandwildcards) => Qs("expand_wildcards", expandwildcards);
		///<summary>Starting offset (default: 0)</summary>
		public UpdateByQueryDescriptor<TDocument> From(long? from) => Qs("from", from);
		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public UpdateByQueryDescriptor<TDocument> IgnoreUnavailable(bool? ignoreunavailable = true) => Qs("ignore_unavailable", ignoreunavailable);
		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public UpdateByQueryDescriptor<TDocument> Lenient(bool? lenient = true) => Qs("lenient", lenient);
		///<summary>Ingest pipeline to set on index requests made by this action. (default: none)</summary>
		public UpdateByQueryDescriptor<TDocument> Pipeline(string pipeline) => Qs("pipeline", pipeline);
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public UpdateByQueryDescriptor<TDocument> Preference(string preference) => Qs("preference", preference);
		///<summary>Query in the Lucene query string syntax</summary>
		public UpdateByQueryDescriptor<TDocument> QueryOnQueryString(string queryonquerystring) => Qs("q", queryonquerystring);
		///<summary>Should the affected indexes be refreshed?</summary>
		public UpdateByQueryDescriptor<TDocument> Refresh(bool? refresh = true) => Qs("refresh", refresh);
		///<summary>Specify if request cache should be used for this request or not, defaults to index level setting</summary>
		public UpdateByQueryDescriptor<TDocument> RequestCache(bool? requestcache = true) => Qs("request_cache", requestcache);
		///<summary>The throttle to set on this request in sub-requests per second. -1 means no throttle.</summary>
		public UpdateByQueryDescriptor<TDocument> RequestsPerSecond(long? requestspersecond) => Qs("requests_per_second", requestspersecond);
		///<summary>
		/// A document is routed to a particular shard in an index using the following formula
		/// <para> shard_num = hash(_routing) % num_primary_shards</para>
		/// <para>OpenSearch will use the document id if not provided. </para>
		/// <para>For requests that are constructed from/for a document OSC will automatically infer the routing key
		/// if that document has a <see cref = "JoinField"/> or a routing mapping on for its type exists on <see cref = "ConnectionSettings"/></para>
		///</summary>
		public UpdateByQueryDescriptor<TDocument> Routing(Routing routing) => Qs("routing", routing);
		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public UpdateByQueryDescriptor<TDocument> Scroll(Time scroll) => Qs("scroll", scroll);
		///<summary>Size on the scroll request powering the update by query</summary>
		public UpdateByQueryDescriptor<TDocument> ScrollSize(long? scrollsize) => Qs("scroll_size", scrollsize);
		///<summary>Explicit timeout for each search request. Defaults to no timeout.</summary>
		public UpdateByQueryDescriptor<TDocument> SearchTimeout(Time searchtimeout) => Qs("search_timeout", searchtimeout);
		///<summary>Search operation type</summary>
		public UpdateByQueryDescriptor<TDocument> SearchType(SearchType? searchtype) => Qs("search_type", searchtype);
		///<summary>The number of slices this task should be divided into. Defaults to 1, meaning the task isn't sliced into subtasks. Can be set to `auto`.</summary>
		public UpdateByQueryDescriptor<TDocument> Slices(long? slices) => Qs("slices", slices);
		///<summary>A comma-separated list of &lt;field&gt;:&lt;direction&gt; pairs</summary>
		public UpdateByQueryDescriptor<TDocument> Sort(params string[] sort) => Qs("sort", sort);
		///<summary>Whether the _source should be included in the response.</summary>
		public UpdateByQueryDescriptor<TDocument> SourceEnabled(bool? sourceenabled = true) => Qs("_source", sourceenabled);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public UpdateByQueryDescriptor<TDocument> SourceExcludes(Fields sourceexcludes) => Qs("_source_excludes", sourceexcludes);
		///<summary>A list of fields to exclude from the returned _source field</summary>
		public UpdateByQueryDescriptor<TDocument> SourceExcludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_excludes", fields?.Select(e => (Field)e));
		///<summary>A list of fields to extract and return from the _source field</summary>
		public UpdateByQueryDescriptor<TDocument> SourceIncludes(Fields sourceincludes) => Qs("_source_includes", sourceincludes);
		///<summary>A list of fields to extract and return from the _source field</summary>
		public UpdateByQueryDescriptor<TDocument> SourceIncludes(params Expression<Func<TDocument, object>>[] fields) => Qs("_source_includes", fields?.Select(e => (Field)e));
		///<summary>Specific 'tag' of the request for logging and statistical purposes</summary>
		public UpdateByQueryDescriptor<TDocument> Stats(params string[] stats) => Qs("stats", stats);
		///<summary>The maximum number of documents to collect for each shard, upon reaching which the query execution will terminate early.</summary>
		public UpdateByQueryDescriptor<TDocument> TerminateAfter(long? terminateafter) => Qs("terminate_after", terminateafter);
		///<summary>Time each individual bulk request should wait for shards that are unavailable.</summary>
		public UpdateByQueryDescriptor<TDocument> Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Specify whether to return document version as part of a hit</summary>
		public UpdateByQueryDescriptor<TDocument> Version(bool? version = true) => Qs("version", version);
		///<summary>Should the document increment the version number (internal) on hit or not (reindex)</summary>
		public UpdateByQueryDescriptor<TDocument> VersionType(bool? versiontype = true) => Qs("version_type", versiontype);
		///<summary>Sets the number of shard copies that must be active before proceeding with the update by query operation. Defaults to 1, meaning the primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)</summary>
		public UpdateByQueryDescriptor<TDocument> WaitForActiveShards(string waitforactiveshards) => Qs("wait_for_active_shards", waitforactiveshards);
		///<summary>Should the request should block until the update by query operation is complete.</summary>
		public UpdateByQueryDescriptor<TDocument> WaitForCompletion(bool? waitforcompletion = true) => Qs("wait_for_completion", waitforcompletion);
	}

	///<summary>Descriptor for UpdateByQueryRethrottle <para>https://opensearch.org/docs/latest/opensearch/rest-api/document-apis/update-by-query/</para></summary>
	public partial class UpdateByQueryRethrottleDescriptor : RequestDescriptorBase<UpdateByQueryRethrottleDescriptor, UpdateByQueryRethrottleRequestParameters, IUpdateByQueryRethrottleRequest>, IUpdateByQueryRethrottleRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.NoNamespaceUpdateByQueryRethrottle;
		///<summary>/_update_by_query/{task_id}/_rethrottle</summary>
		///<param name = "taskId">this parameter is required</param>
		public UpdateByQueryRethrottleDescriptor(TaskId taskId): base(r => r.Required("task_id", taskId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected UpdateByQueryRethrottleDescriptor(): base()
		{
		}

		// values part of the url path
		TaskId IUpdateByQueryRethrottleRequest.TaskId => Self.RouteValues.Get<TaskId>("task_id");
		// Request parameters
		///<summary>The throttle to set on this request in floating sub-requests per second. -1 means set no throttle.</summary>
		public UpdateByQueryRethrottleDescriptor RequestsPerSecond(long? requestspersecond) => Qs("requests_per_second", requestspersecond);
	}
}
