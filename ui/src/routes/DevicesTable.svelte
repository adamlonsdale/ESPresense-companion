<script lang="ts">
  import {createDataTableStore,	dataTableHandler,	tableInteraction,	tableA11y} from '@skeletonlabs/skeleton';
  import { config, devices } from '../lib/stores';
  import type { Node, Device } from '../lib/types';

  let nodes: Node[] | undefined;
</script>

<div class="table-container">
  {#if $devices }
  <table class="table table-hover">
    <thead>
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Room / Floor</th>
        <th>X</th>
        <th>Y</th>
        <th>Z</th>
        <th>Fixes</th>
        <th>Scale</th>
        <th>Confidence</th>
        <th>LastHit</th>
      </tr>
    </thead>
    <tbody>
      {#each $devices as d}
      <tr>
        <td>{@html d.id}</td>
        <td>{@html d.name}</td>
        <td>{@html d.room?.name ?? d.floor?.name ?? "n/a"}</td>
        <td>{@html d.location?.x}</td>
        <td>{@html d.location?.y}</td>
        <td>{@html d.location?.z}</td>
        <td>{@html d.fixes ?? "n/a"}</td>
        <td>{@html d.scale ?? "n/a"}</td>
        <td>{@html d.confidence ?? "n/a"}</td>
        <td>{@html d.lastHit ?? "n/a"}</td>
      </tr>
      {/each}
    </tbody>
  </table>
  {/if}
</div>

<style>
  .table-container { padding: 10px; }
</style>