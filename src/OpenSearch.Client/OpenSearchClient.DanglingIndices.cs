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
using System.Threading;
using System.Threading.Tasks;
using OpenSearch.Net.Specification.DanglingIndicesApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace OpenSearch.Client.Specification.DanglingIndicesApi
{
	///<summary>
	/// Dangling Indices APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IOpenSearchClient.DanglingIndices"/> property
	/// on <see cref = "IOpenSearchClient"/>.
	///</para>
	///</summary>
	public class DanglingIndicesNamespace : NamespacedClientProxy
	{
		internal DanglingIndicesNamespace(OpenSearchClient client): base(client)
		{
		}

		/// <summary>
		/// <c>DELETE</c> request to the <c>dangling_indices.delete_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public DeleteDanglingIndexResponse DeleteDanglingIndex(IndexUuid indexUuid, Func<DeleteDanglingIndexDescriptor, IDeleteDanglingIndexRequest> selector = null) => DeleteDanglingIndex(selector.InvokeOrDefault(new DeleteDanglingIndexDescriptor(indexUuid: indexUuid)));
		/// <summary>
		/// <c>DELETE</c> request to the <c>dangling_indices.delete_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<DeleteDanglingIndexResponse> DeleteDanglingIndexAsync(IndexUuid indexUuid, Func<DeleteDanglingIndexDescriptor, IDeleteDanglingIndexRequest> selector = null, CancellationToken ct = default) => DeleteDanglingIndexAsync(selector.InvokeOrDefault(new DeleteDanglingIndexDescriptor(indexUuid: indexUuid)), ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>dangling_indices.delete_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public DeleteDanglingIndexResponse DeleteDanglingIndex(IDeleteDanglingIndexRequest request) => DoRequest<IDeleteDanglingIndexRequest, DeleteDanglingIndexResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>DELETE</c> request to the <c>dangling_indices.delete_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<DeleteDanglingIndexResponse> DeleteDanglingIndexAsync(IDeleteDanglingIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteDanglingIndexRequest, DeleteDanglingIndexResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>dangling_indices.import_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public ImportDanglingIndexResponse ImportDanglingIndex(IndexUuid indexUuid, Func<ImportDanglingIndexDescriptor, IImportDanglingIndexRequest> selector = null) => ImportDanglingIndex(selector.InvokeOrDefault(new ImportDanglingIndexDescriptor(indexUuid: indexUuid)));
		/// <summary>
		/// <c>POST</c> request to the <c>dangling_indices.import_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<ImportDanglingIndexResponse> ImportDanglingIndexAsync(IndexUuid indexUuid, Func<ImportDanglingIndexDescriptor, IImportDanglingIndexRequest> selector = null, CancellationToken ct = default) => ImportDanglingIndexAsync(selector.InvokeOrDefault(new ImportDanglingIndexDescriptor(indexUuid: indexUuid)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>dangling_indices.import_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public ImportDanglingIndexResponse ImportDanglingIndex(IImportDanglingIndexRequest request) => DoRequest<IImportDanglingIndexRequest, ImportDanglingIndexResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>dangling_indices.import_dangling_index</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<ImportDanglingIndexResponse> ImportDanglingIndexAsync(IImportDanglingIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IImportDanglingIndexRequest, ImportDanglingIndexResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>dangling_indices.list_dangling_indices</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public ListDanglingIndicesResponse List(Func<ListDanglingIndicesDescriptor, IListDanglingIndicesRequest> selector = null) => List(selector.InvokeOrDefault(new ListDanglingIndicesDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>dangling_indices.list_dangling_indices</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<ListDanglingIndicesResponse> ListAsync(Func<ListDanglingIndicesDescriptor, IListDanglingIndicesRequest> selector = null, CancellationToken ct = default) => ListAsync(selector.InvokeOrDefault(new ListDanglingIndicesDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>dangling_indices.list_dangling_indices</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public ListDanglingIndicesResponse List(IListDanglingIndicesRequest request) => DoRequest<IListDanglingIndicesRequest, ListDanglingIndicesResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>dangling_indices.list_dangling_indices</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<ListDanglingIndicesResponse> ListAsync(IListDanglingIndicesRequest request, CancellationToken ct = default) => DoRequestAsync<IListDanglingIndicesRequest, ListDanglingIndicesResponse>(request, request.RequestParameters, ct);
	}
}
