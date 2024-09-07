document.getElementById('search-input').addEventListener('input', function () {
    const searchQuery = document.getElementById('search-input').value;
    fetch(`/Product/Search?search=${encodeURIComponent(searchQuery)}`)
        .then(response => response.json())
        .then(data => {
            const productList = document.getElementById('product-list');
            //const sec = document.getElementById('section-id');
            productList.innerHTML = '';
            //sec.innerHTML = '';
            let a = "";
            let pagein = "";
            let row = 0;
            data.forEach(product => {
                row += 1;
                a += `<tr>
                    <th scope="row">${row}</th>
                    <td>${product.productName}</td>
                    <td>${product.unitPrice}</td>
                    <td>${product.unitsInStock}</td>
                    <td>
                        <a
                            href="/Cart/AddToCart?productId=${product.productId}&search=${searchQuery}"
                            class="btn btn-xs btn-success">Add To Cart</a>
                    </td>
                    </tr>`
            });
            //pagein += `<product-list-pager current-page="${data.currentPage}" page-count="${data.pageCount}" page-size="${data.pageSize}">
            
            //</product-list-pager>`
            //sec.innerHTML = pagein;
            productList.innerHTML = a;
        })
        .catch(error => console.error('Error:', error));
});
