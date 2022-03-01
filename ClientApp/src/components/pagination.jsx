import React, { useState } from "react";

const Pagination = (props) => {
  const { pageNumber, pageSize, totalRecords, onPageClick } = props;
  const [currentPage, setCurrentPage] = useState(pageNumber);

  const totalPages = totalRecords / pageSize;
  const hasNext = currentPage < totalPages;
  const hasPrevious = currentPage > 1;

  const goToPage = (page) => {
    setCurrentPage(page);
    onPageClick({
      pageNumber: page,
    });
  };

  const goToNextPage = () => {
    goToPage(currentPage + 1);
  };

  const goToPreviousPage = () => {
    goToPage(currentPage - 1);
  };

  return (
    <nav aria-label="general-pagination-component">
      <ul class="pagination">
        <li class={`${hasPrevious ? "page-item" : "page-item disabled"}`}>
          <a class="page-link" onClick={goToPreviousPage} tabindex="-1">
            Previous
          </a>
        </li>

        {hasPrevious ? (
          <li class="page-item">
            <a class="page-link" onClick={() => goToPage(currentPage - 1)}>
              {currentPage - 1}
            </a>
          </li>
        ) : null}

        <li class="page-item active">
          <a class="page-link">
            {currentPage} <span class="sr-only">(current)</span>
          </a>
        </li>

        {hasNext ? (
          <li class="page-item">
            <a class="page-link" onClick={() => goToPage(currentPage + 1)}>
              {currentPage + 1}
            </a>
          </li>
        ) : null}

        <li class={`${hasNext ? "page-item" : "page-item disabled"}`}>
          <a class="page-link" onClick={goToNextPage}>
            Next
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default Pagination;
