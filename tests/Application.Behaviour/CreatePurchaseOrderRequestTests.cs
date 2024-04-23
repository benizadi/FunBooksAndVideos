using Application.Commands;
using Application.Handlers;
using Application.Queries;
using Application.Services;
using Application.Services.Processors;
using Contracts;
using DataAccess;
using DataAccess.Repositories;
using FluentAssertions;

namespace Application.Behaviour
{
    public class CreatePurchaseOrderRequestTests
    {
        [Test]
        public async Task When_PurchaseOrderIsValid_ShouldSucceed()
        {
            //Arrange
            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 1,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName = "TestProductName",
                        ProductType = ProductType.Video
                    }
                }
            };
            
            //Act
            var result = await _handler.Handle(new CreatePurchaseOrderRequest(purchaseOrder), CancellationToken.None);

            //Assert
            result.IsSuccess.Should().Be(true);
        }
        
        [Test]
        public async Task When_PurchaseOrderContainsPhysicalProduct_ShouldCreateShippingSlip()
        {
            //Arrange
            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 1,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName = "TestProductName",
                        ProductType = ProductType.Book,
                        UnitPrice = 100
                    }
                },
            };
            
            //Act
            var result = await _handler.Handle(new CreatePurchaseOrderRequest(purchaseOrder), CancellationToken.None);

            //Assert
            result.IsSuccess.Should().Be(true);
            _context.ShippingSlip.First().Should().NotBeNull();
            _context.ShippingSlip.First().CustomerName.Should().Be("Customer1");
        }
        
        [Test]
        public async Task When_PurchaseOrderContainsMembership_ShouldActivateCustomerMembership()
        {
            //Arrange
            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 1,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName = "TestProductName",
                        ProductType = ProductType.Book,
                        UnitPrice = 100
                    },
                },
                Membership =
                    new Membership()
                    {
                        MembershipType = MembershipType.BookClubMembership,
                        Fee = 120
                    }
            };
            
            //Act
            var result = await _handler.Handle(new CreatePurchaseOrderRequest(purchaseOrder), CancellationToken.None);

            //Assert
            result.IsSuccess.Should().Be(true);
            _context.Customer.First(x => x.CustomerId == purchaseOrder.CustomerId).IsActiveMember.Should().Be(true);
        }
        
        [Test]
        public async Task When_PurchaseOrderContainsProducts_ShouldCalculateCorrectTotalPrice()
        {
            //Arrange
            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 1,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName = "TestProductName1",
                        ProductType = ProductType.Book,
                        UnitPrice = 100
                    },
                    new Product()
                    {
                        ProductName = "TestProductName2",
                        ProductType = ProductType.Book,
                        UnitPrice = 50
                    },
                },
                Membership =
                    new Membership()
                    {
                        MembershipType = MembershipType.BookClubMembership,
                        Fee = 120
                    }
            };
            
            //Act
            var result = await _handler.Handle(new CreatePurchaseOrderRequest(purchaseOrder), CancellationToken.None);

            //Assert
            result.IsSuccess.Should().Be(true);
            _context.PurchaseOrders.First().TotalPrice.Should().Be(270);
        }
        
        [Test]
        public async Task When_PurchaseOrderDoesNotContainsPhysicalProduct_ShouldNotCreateShippingSlip()
        {
            //Arrange
            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 1,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName = "TestProductName",
                        ProductType = ProductType.Video,
                        UnitPrice = 100
                    }
                }
            };
            
            //Act
            var result = await _handler.Handle(new CreatePurchaseOrderRequest(purchaseOrder), CancellationToken.None);

            //Assert
            result.IsSuccess.Should().Be(true);
            _context.ShippingSlip.FirstOrDefault().Should().BeNull();
        }
        
        [Test]
        public async Task When_PurchaseOrderDoesNotContainsMembership_ShouldNotActivateCustomerMembership()
        {
            //Arrange
            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 1,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName = "TestProductName",
                        ProductType = ProductType.Book,
                        UnitPrice = 100
                    }
                }
            };
            
            //Act
            var result = await _handler.Handle(new CreatePurchaseOrderRequest(purchaseOrder), CancellationToken.None);

            //Assert
            result.IsSuccess.Should().Be(true);
            _context.Customer.First(x => x.CustomerId == purchaseOrder.CustomerId).IsActiveMember.Should().Be(false);
        }
        
        [SetUp]
        public void Setup()
        {
            // In real world we use FakeDbContext not to rely on Actual DB data, to speed up the test I used the same InMemory DB
            _context = new DatabaseContext();  
            _purchaseOrderRepository = new PurchaseOrderRepository(_context);
            _createPurchaseOrderCommand = new CreatePurchaseOrderCommand(_purchaseOrderRepository);
            _customerRepository = new CustomerRepository(_context);
            _shippingSlipRepository = new ShippingSlipRepository(_context);
            _generateShippingSlipCommand = new GenerateShippingSlipCommand(_shippingSlipRepository);
            _getCustomerQuery = new GetCustomerQuery(_customerRepository);
            _activateMembershipCommand = new ActivateMembershipCommand(_customerRepository);
            
            _memberActivationRuleProcessor = new MemberActivationRuleProcessor(_activateMembershipCommand);
            _shippingSlipRuleProcessor = new ShippingSlipRuleProcessor(_generateShippingSlipCommand, _getCustomerQuery);
            
            _purchaseOrderRuleProcessor = new PurchaseOrderRuleEngine(new List<IPurchaseOrderTypeProcessor>()
            {
                _memberActivationRuleProcessor,
                _shippingSlipRuleProcessor
            });

            _handler = new CreatePurchaseOrderRequest.CreatePurchaseOrderRequestHandler(
                _createPurchaseOrderCommand,
                _purchaseOrderRuleProcessor,
                _getCustomerQuery);
        }


        [TearDown]
        public void FinishTest()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
        
        private CreatePurchaseOrderRequest.CreatePurchaseOrderRequestHandler _handler;
        private ICreatePurchaseOrderCommand _createPurchaseOrderCommand;
        private IPurchaseOrderRepository _purchaseOrderRepository;
        private IActivateMembershipCommand _activateMembershipCommand;
        private IGenerateShippingSlipCommand _generateShippingSlipCommand;
        private IGetCustomerQuery _getCustomerQuery;
        private ICustomerRepository _customerRepository;
        private IShippingSlipRepository _shippingSlipRepository;
        private IPurchaseOrderRuleProcessor _purchaseOrderRuleProcessor;
        private IPurchaseOrderTypeProcessor _memberActivationRuleProcessor;
        private IPurchaseOrderTypeProcessor _shippingSlipRuleProcessor;
        private DatabaseContext _context;
    }
}