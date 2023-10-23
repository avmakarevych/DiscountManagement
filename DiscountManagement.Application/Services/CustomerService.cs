using DiscountManagement.Core.Interfaces;
using DiscountManagement.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using DiscountManagement.Application.Interfaces;
using DiscountManagement.Core.Entities;

namespace DiscountManagement.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public CustomerDTO GetCustomer(Guid id)
    {
        var customer = _customerRepository.Get(id);
        return MapToDTO(customer);
    }

    public IEnumerable<CustomerDTO> GetAllCustomers()
    {
        var customers = _customerRepository.GetAll();
        return customers.Select(MapToDTO);
    }

    public void AddCustomer(CustomerDTO customerDTO)
    {
        var customer = MapToEntity(customerDTO);
        _customerRepository.Add(customer);
    }

    public void UpdateCustomer(CustomerDTO customerDTO)
    {
        var customer = MapToEntity(customerDTO);
        _customerRepository.Update(customer);
    }

    public void DeleteCustomer(Guid id)
    {
        _customerRepository.Remove(id);
    }

    private CustomerDTO MapToDTO(Customer customer)
    {
        return new CustomerDTO
        {
            Id = customer.Id,
            PersonalCode = customer.PersonalCode,
            Name = customer.Name,
            Email = customer.Email,
            Address = customer.Address,
            Discount = customer.Discount
        };
    }

    private Customer MapToEntity(CustomerDTO customerDTO)
    {
        return new Customer
        {
            Id = customerDTO.Id,
            PersonalCode = customerDTO.PersonalCode,
            Name = customerDTO.Name,
            Email = customerDTO.Email,
            Address = customerDTO.Address,
            Discount = customerDTO.Discount
        };
    }
}