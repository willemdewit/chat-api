using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chatApi.Models;
using JsonApiDotNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace chatApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("Conversation"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // add jsonapi dotnet core
            services.AddJsonApi<AppDbContext>(
                opt => opt.Namespace = "api");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseJsonApi();

            // seed db
            AddTestData(dbContext);
        }

        private static void AddTestData(AppDbContext context)
        {
            Conversation firstConversation = new Conversation() { Subject = "First", IsComplete = false };
            Conversation secondConversation = new Conversation() { Subject = "Second", IsComplete = true };
            Participant piet = new Participant() { Name = "Piet", IsPatient = true };
            Participant doc = new Participant() { Name = "Doc", IsPatient = false };

            ConversationParticipant docPietConversation = new ConversationParticipant()
            {
                ConversationId = firstConversation.Id,
                Conversation = firstConversation,
                ParticipantId = piet.Id,
                Participant = piet
            };
            ConversationParticipant pietDocConversation = new ConversationParticipant()
            {
                ConversationId = firstConversation.Id,
                Conversation = firstConversation,
                ParticipantId = doc.Id,
                Participant = doc
            };

            Message hiMessage = new Message()
            {
                _Message = "Hello world",
                ConversationId = firstConversation.Id,
                Conversation = firstConversation,
                Participant = piet,
                ParticipantId = piet.Id,
                SentDateTime = new DateTime(2018, 9, 11, 19, 44, 21)
            };

            firstConversation.Messages = new List<Message>() { { hiMessage } };
            context.Conversations.Add(firstConversation);
            context.Conversations.Add(secondConversation);

            context.Messages.Add(hiMessage);

            context.Participants.Add(piet);
            context.Participants.Add(doc);

            context.ConversationParticipants.Add(docPietConversation);
            context.ConversationParticipants.Add(pietDocConversation);

            context.SaveChanges();
        }
    }
}
