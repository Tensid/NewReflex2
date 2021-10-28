import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import $ from 'jquery';
import 'jszip';
import 'pdfmake';
import 'datatables.net-bs4';
import 'datatables.net-buttons-bs4';
import 'datatables.net-buttons/js/buttons.colVis.js';
import 'datatables.net-buttons/js/buttons.html5.js';
import 'datatables.net-buttons/js/buttons.print.js';
import 'datatables.net-responsive-bs4';
import './buttons.bootstrap4.css';
import './dataTables.bootstrap4.css';
import './responsive.bootstrap4.css';
import { increase, decrease } from '../spinner/spinnerSlice';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';
window.pdfMake.vfs = pdfFonts.pdfMake.vfs;

const DataTable = (props) => {
  const linkButtons = props.linkButtons.map(x => {
    return {
      text: x.displayName,
      className: `${x.url ? '' : 'disabled'}`,
      action: () => window.open(x.url),
      init: (dt, node) => {
        $(node).attr('href', x.url);
      }
    };
  });

  useEffect(() => {
    const table = $('#table').DataTable({
      ajax: (d, callback, settings) => {
        (async () => {
          try {
            props.increase();
            const estateId = props.searchResult.value;
            const distance = $('#radius_input').val();
            const data = await props.getTableData(estateId, distance);
            props.setCount(data.length);
            callback({ data });
          }
          catch (e) {
            console.log(e.toString());
          }
          finally {
            props.decrease();
          }
        })();
      },
      columns: props.columns,
      dom: 'Bfrtip',
      order: [[1, 'asc']],
      columnDefs: [
        { responsivePriority: 1, targets: 0 },
        { responsivePriority: 2, targets: 1 }
      ],
      buttons: [
        {
          extend: 'colvis',
          text: 'Välj kolumner',
          className: 'mr-2'
        },
        {
          extend: 'collection',
          className: 'mr-2 rounded',
          text: 'Exportera',
          buttons: [
            {
              extend: 'copy',
              text: 'Kopiera',
              exportOptions: {
                columns: ':visible'
              }
            },
            {
              extend: 'excelHtml5',
              exportOptions: {
                columns: ':visible'
              }
            },
            // {
            //   extend: 'csv',
            //   exportOptions: {
            //     columns: ':visible'
            //   }
            // },
            // {
            //   extend: 'pdf',
            //   exportOptions: {
            //     columns: ':visible'
            //   }
            // }
          ]
        },
        {
          extend: 'collection',
          className: 'rounded',
          text: 'Rapporter',
          buttons: linkButtons
        }
      ],
      paging: true,
      language: {
        processing: 'Bearbetar...',
        search: 'Filtrera:',
        lengthMenu: 'Visa _MENU_ rader',
        info: 'Visar _START_ till _END_ av totalt _TOTAL_ rader',
        infoEmpty: 'Visar 0 till 0 av totalt 0 rader',
        infoFiltered: '(filtrerade från totalt _MAX_ rader)',
        infoPostFix: '',
        loadingRecords: 'Laddar...',
        zeroRecords: 'Hittade inga matchande resultat',
        emptyTable: 'Tabellen innehåller ingen data',

        paginate: {
          first: 'Första',
          previous: 'Föregående',
          next: 'Nästa',
          last: 'Sista'
        },

        aria: {
          sortAscending: ': aktivera för att sortera kolumnen i stigande ordning',
          sortDescending: ': aktivera för att sortera kolumnen i fallande ordning'
        }
      },
      selected: true
    });

    $('#table_wrapper .btn-secondary').removeClass('btn-secondary').addClass('btn-primary btn-sm');
    $('#table_wrapper .btn-group').addClass('p-0 col-auto');
    $('#table_filter').addClass('p-0 col-auto pull-right');
    $('#table_info').addClass('p-0');

    table.buttons().container().appendTo('#table_wrapper .col-md-6:eq(0)');

    $('#radius_input').on('blur', e =>
      e.currentTarget.value = Math.max(Math.min(e.currentTarget.value, e.currentTarget.max), e.currentTarget.min)
    );

    $('#radius_input').on('keyup', e => {
      if (e.keyCode === 13) {
        e.currentTarget.value = Math.max(Math.min(e.currentTarget.value, e.currentTarget.max),
          e.currentTarget.min);
        table.ajax.reload();
      };
    });
    $('#get_button').click(() => {
      table.ajax.reload();
    });
  }, [linkButtons]);

  return (
    <div>
      <div className="form-inline justify-content-end">
        <div className="form-group mb-2">
          <label type="text" readOnly className="form-control-plaintext" value="Sök" title="Sök närliggande fastigheter inom radie">Sök:</label>
        </div>
        <div className="form-group mx-2 mb-2">
          <input type="number" className="form-control" min="0" max="1000" defaultValue="0" id="radius_input" placeholder="Meter"></input>
        </div>
        <button id="get_button" className="btn btn-primary mb-2">Hämta</button>
      </div>
      <table id="table" className="table table-hover table-sm table-striped " style={{ 'width': '100%', 'bordeCollapse': 'collapse!important' }}>
        <thead>
          <tr>
            {props.headers.map((td) => <td key={td}>{td}</td>)}
          </tr>
        </thead>
      </table>
    </div>
  );
};

const mapDispatch = { increase, decrease };

const mapStateToProps = (state, ownProps) => ({
  searchResult: state.searchResult,
  setCount: ownProps.setCount
});

export default connect(
  mapStateToProps,
  mapDispatch
)(DataTable);
