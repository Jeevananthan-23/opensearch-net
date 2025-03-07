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
using OpenSearch.Net.Specification.IngestApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace OpenSearch.Client.Specification.IngestApi
{
	///<summary>
	/// Ingest APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IOpenSearchClient.Ingest"/> property
	/// on <see cref = "IOpenSearchClient"/>.
	///</para>
	///</summary>
	public class IngestNamespace : NamespacedClientProxy
	{
		internal IngestNamespace(OpenSearchClient client): base(client)
		{
		}

		/// <summary>
		/// <c>DELETE</c> request to the <c>ingest.delete_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public DeletePipelineResponse DeletePipeline(Id id, Func<DeletePipelineDescriptor, IDeletePipelineRequest> selector = null) => DeletePipeline(selector.InvokeOrDefault(new DeletePipelineDescriptor(id: id)));
		/// <summary>
		/// <c>DELETE</c> request to the <c>ingest.delete_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<DeletePipelineResponse> DeletePipelineAsync(Id id, Func<DeletePipelineDescriptor, IDeletePipelineRequest> selector = null, CancellationToken ct = default) => DeletePipelineAsync(selector.InvokeOrDefault(new DeletePipelineDescriptor(id: id)), ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>ingest.delete_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public DeletePipelineResponse DeletePipeline(IDeletePipelineRequest request) => DoRequest<IDeletePipelineRequest, DeletePipelineResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>DELETE</c> request to the <c>ingest.delete_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<DeletePipelineResponse> DeletePipelineAsync(IDeletePipelineRequest request, CancellationToken ct = default) => DoRequestAsync<IDeletePipelineRequest, DeletePipelineResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.get_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public GetPipelineResponse GetPipeline(Func<GetPipelineDescriptor, IGetPipelineRequest> selector = null) => GetPipeline(selector.InvokeOrDefault(new GetPipelineDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.get_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<GetPipelineResponse> GetPipelineAsync(Func<GetPipelineDescriptor, IGetPipelineRequest> selector = null, CancellationToken ct = default) => GetPipelineAsync(selector.InvokeOrDefault(new GetPipelineDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.get_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public GetPipelineResponse GetPipeline(IGetPipelineRequest request) => DoRequest<IGetPipelineRequest, GetPipelineResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.get_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<GetPipelineResponse> GetPipelineAsync(IGetPipelineRequest request, CancellationToken ct = default) => DoRequestAsync<IGetPipelineRequest, GetPipelineResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.processor_grok</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public GrokProcessorPatternsResponse GrokProcessorPatterns(Func<GrokProcessorPatternsDescriptor, IGrokProcessorPatternsRequest> selector = null) => GrokProcessorPatterns(selector.InvokeOrDefault(new GrokProcessorPatternsDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.processor_grok</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<GrokProcessorPatternsResponse> GrokProcessorPatternsAsync(Func<GrokProcessorPatternsDescriptor, IGrokProcessorPatternsRequest> selector = null, CancellationToken ct = default) => GrokProcessorPatternsAsync(selector.InvokeOrDefault(new GrokProcessorPatternsDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.processor_grok</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public GrokProcessorPatternsResponse GrokProcessorPatterns(IGrokProcessorPatternsRequest request) => DoRequest<IGrokProcessorPatternsRequest, GrokProcessorPatternsResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>ingest.processor_grok</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<GrokProcessorPatternsResponse> GrokProcessorPatternsAsync(IGrokProcessorPatternsRequest request, CancellationToken ct = default) => DoRequestAsync<IGrokProcessorPatternsRequest, GrokProcessorPatternsResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>ingest.put_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public PutPipelineResponse PutPipeline(Id id, Func<PutPipelineDescriptor, IPutPipelineRequest> selector) => PutPipeline(selector.InvokeOrDefault(new PutPipelineDescriptor(id: id)));
		/// <summary>
		/// <c>PUT</c> request to the <c>ingest.put_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<PutPipelineResponse> PutPipelineAsync(Id id, Func<PutPipelineDescriptor, IPutPipelineRequest> selector, CancellationToken ct = default) => PutPipelineAsync(selector.InvokeOrDefault(new PutPipelineDescriptor(id: id)), ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>ingest.put_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public PutPipelineResponse PutPipeline(IPutPipelineRequest request) => DoRequest<IPutPipelineRequest, PutPipelineResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>PUT</c> request to the <c>ingest.put_pipeline</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<PutPipelineResponse> PutPipelineAsync(IPutPipelineRequest request, CancellationToken ct = default) => DoRequestAsync<IPutPipelineRequest, PutPipelineResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ingest.simulate</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public SimulatePipelineResponse SimulatePipeline(Func<SimulatePipelineDescriptor, ISimulatePipelineRequest> selector = null) => SimulatePipeline(selector.InvokeOrDefault(new SimulatePipelineDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>ingest.simulate</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<SimulatePipelineResponse> SimulatePipelineAsync(Func<SimulatePipelineDescriptor, ISimulatePipelineRequest> selector = null, CancellationToken ct = default) => SimulatePipelineAsync(selector.InvokeOrDefault(new SimulatePipelineDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ingest.simulate</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public SimulatePipelineResponse SimulatePipeline(ISimulatePipelineRequest request) => DoRequest<ISimulatePipelineRequest, SimulatePipelineResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>ingest.simulate</c> API, read more about this API online:
		/// <para></para>
		/// <a href = ""></a>
		/// </summary>
		public Task<SimulatePipelineResponse> SimulatePipelineAsync(ISimulatePipelineRequest request, CancellationToken ct = default) => DoRequestAsync<ISimulatePipelineRequest, SimulatePipelineResponse>(request, request.RequestParameters, ct);
	}
}
