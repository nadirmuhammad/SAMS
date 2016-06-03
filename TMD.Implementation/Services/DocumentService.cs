﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Common;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public int AddDocuments(List<Document> documents, int refrenceId, DocumentType refrenceType)
        {
            foreach (var document in documents)
            {
                document.RefrenceId = refrenceId;
                document.RefrenceType = (int) refrenceType;
                documentRepository.Add(document);
            }
            documentRepository.SaveChanges();
            return 1;
        }

        public bool DeleteDocument(int documentId)
        {
            return true;
        }
        public Document GetDocumentById(long id)
        {
            return documentRepository.Find(id);
        }
        public IEnumerable<Document> GetAllDocumentByRefID(int id)
        {
            return null;
        }
    }
}