<?php

namespace App\Http\Controllers;

use App\Models\MeuController;
use Illuminate\Http\Request;

class MeuControllerController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return view('principal');
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        //
    }

    /**
     * Display the specified resource.
     */
    public function show(MeuController $meuController)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(MeuController $meuController)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, MeuController $meuController)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(MeuController $meuController)
    {
        //
    }
}
