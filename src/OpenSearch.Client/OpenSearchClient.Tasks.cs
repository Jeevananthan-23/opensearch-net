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
using OpenSearch.Net.Specification.TasksApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace OpenSearch.Client.Specification.TasksApi
{
	///<summary>
	/// Tasks APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IOpenSearchClient.Tasks"/> property
	/// on <see cref = "IOpenSearchClient"/>.
	///</para>
	///</summary>
	public class TasksNamespace : NamespacedClientProxy
	{
		internal TasksNamespace(OpenSearchClient client): base(client)
		{
		}

		/// <summary>
		/// <c>POST</c> request to the <c>tasks.cancel</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public CancelTasksResponse Cancel(Func<CancelTasksDescriptor, ICancelTasksRequest> selector = null) => Cancel(selector.InvokeOrDefault(new CancelTasksDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>tasks.cancel</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public Task<CancelTasksResponse> CancelAsync(Func<CancelTasksDescriptor, ICancelTasksRequest> selector = null, CancellationToken ct = default) => CancelAsync(selector.InvokeOrDefault(new CancelTasksDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>tasks.cancel</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public CancelTasksResponse Cancel(ICancelTasksRequest request) => DoRequest<ICancelTasksRequest, CancelTasksResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>tasks.cancel</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public Task<CancelTasksResponse> CancelAsync(ICancelTasksRequest request, CancellationToken ct = default) => DoRequestAsync<ICancelTasksRequest, CancelTasksResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public GetTaskResponse GetTask(TaskId taskId, Func<GetTaskDescriptor, IGetTaskRequest> selector = null) => GetTask(selector.InvokeOrDefault(new GetTaskDescriptor(taskId: taskId)));
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public Task<GetTaskResponse> GetTaskAsync(TaskId taskId, Func<GetTaskDescriptor, IGetTaskRequest> selector = null, CancellationToken ct = default) => GetTaskAsync(selector.InvokeOrDefault(new GetTaskDescriptor(taskId: taskId)), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public GetTaskResponse GetTask(IGetTaskRequest request) => DoRequest<IGetTaskRequest, GetTaskResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public Task<GetTaskResponse> GetTaskAsync(IGetTaskRequest request, CancellationToken ct = default) => DoRequestAsync<IGetTaskRequest, GetTaskResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.list</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public ListTasksResponse List(Func<ListTasksDescriptor, IListTasksRequest> selector = null) => List(selector.InvokeOrDefault(new ListTasksDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.list</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public Task<ListTasksResponse> ListAsync(Func<ListTasksDescriptor, IListTasksRequest> selector = null, CancellationToken ct = default) => ListAsync(selector.InvokeOrDefault(new ListTasksDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.list</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public ListTasksResponse List(IListTasksRequest request) => DoRequest<IListTasksRequest, ListTasksResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>tasks.list</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/">https://opensearch.org/docs/latest/opensearch/rest-api/cat/cat-tasks/</a>
		/// </summary>
		public Task<ListTasksResponse> ListAsync(IListTasksRequest request, CancellationToken ct = default) => DoRequestAsync<IListTasksRequest, ListTasksResponse>(request, request.RequestParameters, ct);
	}
}
